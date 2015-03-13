# Introduction #

Visual Studio 2005 використовує CabWiz для генерації CAB у проекті інсталяції. Проте виникають проблеми, якщо у проект інсталяцію включено файли з однаковими іменами (хоч і в різних папках ці файли знаходяться).

# Details #

Існує фікс, який дозволяє виправити цей дефект CabWiz.
Скачати файл [CabWizFixerInstaller.zip (18k)](http://www.mobilepractices.net/cabwizfixerinstaller.zip)
Його достатньо запустити, після чого як раніше створювати CAB у студії, але вже проблеми із іменами-дублікатами не повинно бути.
Детальна інформація [тут](http://www.mobilepractices.com/2008/09/cabwizfixer-support-for-files-with-same.htmlCab).

Щоб анінсталювати фікс, потрібно виконати
```
CabWizFixerInstaller.exe /uninstall
```