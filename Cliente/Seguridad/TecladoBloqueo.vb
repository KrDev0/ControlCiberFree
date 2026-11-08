Imports System.Runtime.InteropServices

''' <summary>
''' Hook de teclado de bajo nivel: traga Win, Alt+Tab, Alt+Esc y Ctrl+Esc
''' solo mientras la pantalla de bloqueo está visible.
''' Ctrl+Alt+Supr NO se puede bloquear desde el programa (requiere directiva de grupo).
''' </summary>
Public Module TecladoBloqueo
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_SYSKEYDOWN As Integer = &H104
    Private Const VK_TAB As Integer = 9
    Private Const VK_ESCAPE As Integer = 27
    Private Const VK_LWIN As Integer = 91
    Private Const VK_RWIN As Integer = 92
    Private Const VK_CONTROL As Integer = &H11
    Private Const LLKHF_ALTDOWN As Integer = &H20

    Private _hook As IntPtr = IntPtr.Zero
    Private _proc As HookProc = Nothing ' retener: si el GC lo libera, el hook muere

    Private Delegate Function HookProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

    <StructLayout(LayoutKind.Sequential)>
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function SetWindowsHookEx(idHook As Integer, lpfn As HookProc,
                                      hMod As IntPtr, dwThreadId As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Function UnhookWindowsHookEx(hhk As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Function CallNextHookEx(hhk As IntPtr, nCode As Integer,
                                    wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Function GetAsyncKeyState(vKey As Integer) As Short
    End Function

    Public Sub Instalar()
        Try
            If _hook <> IntPtr.Zero Then Return
            _proc = AddressOf Gancho
            _hook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(Nothing), 0)
        Catch
        End Try
    End Sub

    Public Sub Desinstalar()
        Try
            If _hook <> IntPtr.Zero Then UnhookWindowsHookEx(_hook)
        Catch
        Finally
            _hook = IntPtr.Zero
        End Try
    End Sub

    Private Function Gancho(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        Try
            If nCode >= 0 AndAlso (wParam = CType(WM_KEYDOWN, IntPtr) OrElse wParam = CType(WM_SYSKEYDOWN, IntPtr)) Then
                Dim k As KBDLLHOOKSTRUCT = Marshal.PtrToStructure(Of KBDLLHOOKSTRUCT)(lParam)
                Dim altAbajo As Boolean = (k.flags And LLKHF_ALTDOWN) <> 0
                Dim ctrlAbajo As Boolean = (GetAsyncKeyState(VK_CONTROL) And &H8000) <> 0
                If k.vkCode = VK_LWIN OrElse k.vkCode = VK_RWIN Then Return CType(1, IntPtr)
                If altAbajo AndAlso (k.vkCode = VK_TAB OrElse k.vkCode = VK_ESCAPE) Then Return CType(1, IntPtr)
                If ctrlAbajo AndAlso k.vkCode = VK_ESCAPE Then Return CType(1, IntPtr)
            End If
        Catch
        End Try
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function
End Module
