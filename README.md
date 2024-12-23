﻿<a href="https://discord.gg/dxkC5DPgRY"><img src='https://discordapp.com/api/guilds/779755166017519666/widget.png?style=shield'></a>

# Conspiratio.WinForms

**Hinweis: Dieser Client wird nur noch sporadisch weiterentwickelt und damit voraussichtlich auch keine neuen großen Features mehr erhalten, nur noch Fehlerbehebungen. Stattdessen arbeiten wir an einem neuen Client mit Unity (Link folgt), der ebenfalls Open Source sein wird. Dazu suchen wir nach wie vor tatkräftige Unterstützung (Grafik, Programmierung, Musik/Sounds, Konzeption).**

Hier findet Ihr den aktuellen Stand des WinForms Spieleclients von Conspiratio, so wie er auch auf der Website herunter geladen werden kann.

## Mitmachen

Ihr wollt Euch an diesem Projekt beteiligen? Großartig! Tretet einfach mit uns über [Discord](https://discord.gg/dxkC5DPgRY) oder oldschool per <a href="&#109;&#97;&#105;&#108;&#116;&#111;&#58;%6D%61%69%6C%40%63%6F%6E%73%70%69%72%61%74%69%6F%2E%6E%65%74">E-Mail</a> in Kontakt und wir klären die Details.  
_Jegliche Hilfe ist willkommen._

### Git Workflow

**Wichtig: Wir committen und pushen nie direkt in den master Branch!**  
Der Grund ist einfach mangelnde Transparenz und fehlendes 4-Augen-Prinzip bzw. fehlende Kontrolle durch mind. einen anderen Entwickler.

Für jede Änderung an Conspiratio muss daher immer ein neuer, persönlicher Branch erstellt werden. Der Name des Branches sollte immer mit einem der folgenden Namen beginnen, gefolgt von einem Schrägstrich:
- improvement (= Verbesserung des Code oder einer Funktion im Spiel, auch Refaktorisierungen)
- fix (= Korrektur)
- feature (= neue Funktion des Spiels)

_Beispiel:_ fix/absturz-bei-ueberfall

Es sollten außerdem Umlaute und Sonderzeichen vermieden werden und es können außerdem aufgrund von technischen Restriktionen im Branchnamen Leerzeichen nicht verwendet werden, weshalb wir hier stattdessen Bindestriche verwenden.

Ist der eigene Branch dann soweit stabil und enthält alle gewünschten Änderungen/Erweiterungen, dann kann  mittels Pull Request eine Anfrage auf den Merge in den master Branch erstellt werden. Diese sollte immer einem anderen Entwickler zur Prüfung zugewiesen werden, welche einen kleinen Code Review macht, ggf. Feedback zum Code gibt und nach Ausbesserung den Branch dann auch mergt. Eigene Branches sollten nur in Ausnahmefällen selbst gemergt werden (z.B. zeitliche Dringlichkeit).

### Code Guidelines

Als Coding-Richtlinien für C# nutzen wir insbesondere für neuen Code folgende Referenz, da sich diese mittlerweile als Standard durchgesetzt hat:  
https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/inside-a-program/coding-conventions

Bezüglich der Benennung und der Standards wird zusätzlich noch diese Referenz herangezogen:  
https://www.dofactory.com/reference/csharp-coding-standards

Dabei ist bitte zu beachten, dass wir hier als Sprache der Kommentare im Code und auch der meisten Bezeichner deutsch verwenden, da die gesamte bestehende Codebase schon deutsch aufgebaut ist. Natürlich muss jetzt nicht jedes Keyword in jeder Methode komplett deutsch sein, z.B. wäre `GetUmsatzProSpieler` vollkommen legitim (da Get einfach für jeden Entwickler Standard sein sollte), problematisch wäre allerdings etwas wie `GetVolumeOfSalesPerPlayer`, da wir solche Begriffe sonst nirgendwo finden, weder in der Spieloberfläche noch im bestehenden Code und es daher schnell Verwirrungen geben kann, was nun gemeint ist.

Alter Code kann und sollte gerne nach und nach auf diese Richtlinien umgestellt werden, damit es später kein Durcheinander gibt, das hat aber zunächst mal nicht die höchste Priorität. Sollte man aber älteren Code verändern oder refaktorisieren, dann sollte man sich die Mühe machen, und hier auch die neuen Guidelines anwenden, frei nach dem Pfadfindermotto:  
_Hinterlasse einen Ort (Code) immer in einem besseren Zustand als du ihn vorgefunden hast._

### Dokumentation

Die Dokumentation von umfangreichen Features oder sonstigen interessanten Methoden, Klassen etc. im Code erfolgt im [Github Wiki](https://github.com/Conspiratio/Conspiratio.WinForms/wiki).

### Changelog

Vorab: Wir nutzen einiges aus diesem Konzept hier: https://keepachangelog.com/de/1.0.0/

Der Changelog wird in der Datei [CHANGELOG.md](https://github.com/Conspiratio/Conspiratio.WinForms/blob/master/CHANGELOG.md) gepflegt, direkt hier im Root. Wichtig ist, dass jede Änderung hier dokumentiert wird, und zwar immer im Bereich "Unreleased". Das bedeutet im Umkehrschluss, dass jeder Pull Request also auch immer eine Änderungen an der Changelog-Datei enthalten muss, sonst ist er nicht vollständig.

Im Changelog nutzen wir folgende Gruppen zur Unterteilung der Änderungen:

- Erweiterungen
- Änderungen
- Korrekturen
- Balancing

## Kompilierung
Bitte bei der Kompilierung darauf achten, dass folgende Dateien im bin-Ordner liegen:
- CloisterBlack.ttf
- CurInfo.ani
- CurMinus.ani
- CurPlus.ani
- CurSword.ani
- CurWait.ani
- CurWait.cur

Für das Setup sind noch folgende Dateien wichtig:
- Produktion.pdf
- ReadMe.txt

Diese Dateien befinden sich im Repository unter Conspiratio-Programm/Conspiratio/Anwendungsordner/. 

Projekte ursprünglich erstellt für: Visual Studio 2015  
Kompatibel mit: Visual Studio 2017, 2019

## Sonstige Systemvoraussetzungen:
- .NET Framework 4.6.2

## NUGET Pakete, die verwendet werden
- [NAudio](https://www.nuget.org/packages/NAudio/)

## Setup
- Als dritte und hoffentlich vorerst letzte Versuch habe ich im Ordner "Conspiratio.Setup" ein Advanced Installer Projekt erstellt (Conspiratio.Setup.aip). Advanced Installer ist in der Grundversion kostenfrei und  sehr einfach zu bedienen, weshalb ich mich für dieses Tool entschieden habe: https://www.advancedinstaller.com/  
Ausblick: Mit der "Professional" Version hätten wir sogar die Möglichkeit, das Update Tool von Advanced Installer zu nutzen und könnten den Spielern die Option geben, Updates von Conspiratio bequem automatisch herunterladen und installieren zu können, ohne weitere Eingriffe.

## Musik und Sound Credits

Wir benutzen freie Musik und Sounds und bedanken uns dafür bei:

### Musik

- [Jason Shaw](https://audionautix.com/) (Lizenz: [Creative Commons Attribution 4.0 International License](https://creativecommons.org/licenses/by/4.0)) für
  - Noel
  - 30 Second Classical
  - Tempting Fate
  - The Deadly Year
  - The Deadly Year
  - The Talk
  - Big Intro #2
  - Enemy Ships
  - Epic TV Theme
  - Hero In Peril
  - High Tension
  - Imperial Morning
  - Night Runner
  - Remember The Heroes
  - Stalking Prey
  - Warfare Bed
  - Pendulum Waltz
  - Road To Kilcoo
  - The Angels Weep
  - Egyptian Crawl
  - Temptation March
  - Wheel Of Karma
  - Parting Glass
  - A Tall Ship
  - Legends Of The River
  - Renaissance
  - Sundays Child
  - The Master
  - The Mighty Kingdom
  - Triumphant Return
  - Troubled Bridges
  - Turkish Dance
  - What Child Is This
  - The Big Decision
- [Strobotone](https://freemusicarchive.org/music/Strobotone/) (Lizenz: [Attribution-NoDerivatives 4.0 International License](https://creativecommons.org/licenses/by-nd/4.0)) für
  - Medieval Theme 02
- [Michael Ziege](https://siggiziege.de/) für
  - Conspiratio Theme - Idee 01

### Sounds

- [csmag](https://freesound.org/people/csmag/) (Lizenz: [Creative Commons 0 License](https://creativecommons.org/publicdomain/zero/1.0/))
  - Synth1 Bongo-01.wav
  - Synth1 Bongo-02.wav
- [BraveFrog](https://freesound.org/people/BraveFrog/) (Lizenz: [Creative Commons 0 License](https://creativecommons.org/publicdomain/zero/1.0/))
  - coins.wav
- [sarson](https://freesound.org/people/sarson/) (Lizenz: [Creative Commons 0 License](https://creativecommons.org/publicdomain/zero/1.0/))
  - Arras.wav
- [florian_reinke](https://freesound.org/people/florian_reinke/)
  - click1.wav
- [bevibeldesign](https://freesound.org/people/bevibeldesign/)
  - Trumpet Fanfare