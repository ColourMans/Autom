#NoEnv
SendMode Input
SetWorkingDir %A_ScriptDir%
#SingleInstance ignore
Menu, Tray, Tip, Autom
Menu, Tray, NoStandard
Menu, Tray, Icon, C:\Progs\Autom\burn.ico,1,1
Menu, Tray, Add, E&xit, ExitHandler

temp  := 45
temp2 := 45
temp3 := 45
temp4 := 45
flgfan := 0
flgfan2 := 0
flgfansch := 0
Metka1:
Therm := DllCall("TempSys\GetTemp")
Menu, Tray, Tip, Autom %Therm% C
temp2 := temp
temp3 := ((temp2 + temp) / 2)
temp4 := ((temp3 + temp2 + temp) / 3)
temp := Therm
if (temp4 >= 68)
{
    flgfansch := flgfansch + 1
    if (flgfansch >= 12)
    {
        flgfan := 0
        flgfansch := 1
    }
    if (flgfan == 0 && flgfan2 == 0 && flgfansch == 1)
    {
        Result := DllCall("LenovoEmExpandedAPI\SetCleanDust", UInt, 1, UInt, 0)
        flgfan := 1
    }
}
if (temp3 <= 66)
{
    if (flgfan == 1 && flgfan2 == 0)
    {
        Result := DllCall("LenovoEmExpandedAPI\SetCleanDust", UInt, 0, UInt, 0)
        flgfan := 0
        flgfansch := 0
    }
}
Sleep, 11197
Goto, Metka1
return

ExitHandler:
ExitApp 
return

MButton::Send {F11}
XButton1::Send ^v
XButton2::Send ^c
WheelLeft::Send {Volume_Down}
WheelRight::Send {Volume_Up}
return