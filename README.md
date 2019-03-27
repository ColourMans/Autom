![Autom]

The program is based on the NBFC source code - NoteBook FanControl.
The function of reading the EC register 0х0B is taken specifically. There is a processor temperature in it.
Everything else is removed from the source.

Created TempSys.dll library based on ec-probe.exe from the NBFC package

This library and library from the standard utility Lenovon Energy Management LenovoEmExpandedAPI.dll is connected to the script for AutoHotkey v.1 https://www.autohotkey.com on which the rest of the logic of the Autom.exe program is written.

Namely, the program reads the temperature every 11 seconds.
If it exceeds 68C, the program includes fan cleaning in Lenovon Energy Management.
When the temperature drops below 66C degrees, the cleaning of the fans is turned off.

In addition, changes in the functions of mice with additional buttons have been added to the program.

MButton - The middle button duplicates the F11 keystroke, expands supporting windows to full screen, for example, Internet Browsers, and you can also assign a full screen in MPC-HC and other applications.

XButton1 - Ctrl + C - Copy

XButton2 - Ctrl + M - Paste

WheelLeft - Wheel Left - Volume Up

WheelRight - Wheel Right - Volume Down

Therefore, no additional mouse drivers are required.

The program requires to run on behalf of the Administrator! Otherwise, the temperature cannot be read.
Therefore, the autorun of the program is best prescribed in the Windows Task Scheduler. Since there you can put the property - Run with the highest rights. And it will not require confirmation from you, when the UAC is on.

How to do it? described here:
https://www.sevenforums.com/tutorials/67503-task-create-run-program-startup-log.html

The program was developed for my Lenovo G500, but I think it should work correctly on all Lenovo laptops with Lenovo Energy Management 8.0.2.11 - https://download.lenovo.com/consumer/mobiles/wwem018e.exe

I don’t plan change this program, if it doesn’t work for you, or if you need something else, change and understand further the instructions themselves and what to do here: https://github.com/hirschmann/nbfc/wiki/How-to-build-NBFC
And you may need it if your EC register 0x0B is not at a temperature, in which case you will have to use Visual Studio and rebuild the project.
For other changes, you will need to install AutoHotkey v.1 https://www.autohotkey.com which is much easier.

## Downloads

| Source | Link | Status |
|---|---|---|
| Download from github | Autom releases](https://github.com/ColourMans/Autom/releases) | [![Github All Releases](https://img.shields.io/github/downloads/ColourMans/Autom/total.svg)](https://github.com/ColourMans/Autom/releases) |


---------------------------------------------------------------------------------------------------------------


Программа базируется на исходном коде NBFC - NoteBook FanControl.
Конкретно взята функция чтения EC регистра 0х0B в которм имеется температура процессора.
Всё остальное из исходника удалено.

Создана библиотека TempSys.dll на основе ec-probe.exe из пакета NBFC

Эта билиотека и бибилиотека от стандартной утилиты Lenovon Energy Management LenovoEmExpandedAPI.dll подключается в скрипт для AutoHotkey v.1 https://www.autohotkey.com на котором написана остальная логика программы Autom.

А именно программа, каждые 11 секунд считывает температуру.
Если она превышает 68С программа включает очистку вентилятора в Lenovon Energy Management.
Когда температура снижается ниже 66С градусов очистка вентиляторов выключается.

Плюс ко всему в программу добавлены изменения функций мышей, имеющих дополнительные кнопки.

MButton - Средняя кнопка дублирует нажатие клавиши F11, разворачивает поддерживающие эту функию окна на полный экран, например Интернет Броузеры и так же можно назначить полный экран в MPC-HC и прочих приложениях.

XButton1 - Ctrl + С - Копировать

XButton2 - Ctrl + М - Вставить

WheelLeft - Колесо влево - Уменьшит громкость

WheelRight - Колесо вправо - Увеличить громкость

Поэтому не требуется использовать дополнительные драйверы на мышь.

Программа требует для работы запуск от имени Администратора! Иначе температура не считывается.
Поэтому автозапуск программы лучше всего прописывать в Планировщик заданий Windows. Так как там можно поставить свойство - Выполнить с наивысшими правами. И это не будет требовать подтверждения от Вас, при включеном UAС.

Как это сделать? описано тут:
https://pomogaemkompu.temaretik.com/1019601943114811563/kak-vruchnuyu-dobavit-lyubuyu-programmu-v-avtozagruzku-windows/

Программа разрабатывалась к моему Lenovo G500, но думаю должна корректно работать на всех Lenovo ноутбуках с Lenovo Energy Management 8.0.2.11 - https://download.lenovo.com/consumer/mobiles/wwem018e.exe

Как то доробатывать и изменять эту программу я не планирую, если у Вас она не работает, или Вам нужно что то иное, изменяйте и разбирайтесь дальше сами инструкция как и в чём сделать билд тут: https://github.com/hirschmann/nbfc/wiki/How-to-build-NBFC
А вам может это понадобиться если Ваш EC регистр с температурой не 0х0B, в этом случае вам придётся воспользоваться Visual Studio и пересобрать проэкт.
Для остальных изменений понадобиться установить AutoHotkey v.1 https://www.autohotkey.com это горазда легче.

## Скачать

| Исходный код | Ссылка | Состояние |
|---|---|---|
| Download from github | Autom releases](https://github.com/ColourMans/Autom/releases) | [![Github All Releases](https://img.shields.io/github/downloads/ColourMans/Autom/total.svg)](https://github.com/ColourMans/Autom/releases) |