# KRAVSPECIFIKATION NITRILON
Kravspecifikationen opdeles i subsystems:

Subsystem 01: Event Rating
Subsystem 02: Medlemshåndtering
Subsystem 03: Rollespilsgrupper

## Subsystem 01: Event Rating
Aktører:
* System: Den tablet og webpage som gæsten interagerer med. 
* Gæst: En person til Nitricon event.
* Eventansvarlig: Den der skal have vist oversigterne over gæsternes bedømmelse.
* Klargøringsansvarlig: Den der klargører devicet til at gæsterne kan rate eventet.

01. Den eventansvarlige skal kunne vælge et event for at få vist antallet af bedømmelser i hver bedømmelsesniveau.
02. Den klargøringsansvarlige skal få vist de events der kan vælges, når devicet skal klargøres til brug.
03. De events der skal vises til den klargøringsansvarlige, er igangværende og og fremtidige events.
04. Når den klargøringsansvarlige har valgt et event, skal systemet viderestille til bedømmelsessiden.
05. En gæst skal kunne bedømme oplevelsen af et event, med valg af én værdi på en skala med fem niveauer.
06. Gæsten skal have feedback efter indtastningen af bedømmelsen.
07. Systemet skal automatisk klargøre til næste indtastning, efter en indtastning.

## Subsystem 02: Medlemshåndtering
Aktører:
* Medlemsansvarlig: Håndtering af medlemmer. Tilføje, fjerne og se medlemmer samt medlemskab.

01. Den medlemsansvarlige skal kunne se alle medlemmer og se hvilket type medlemsskab de har.
02. Den medlemsansvarlige skal kunne tilføje nye medlemmer.
03. Den medlemsansvarlige skal kunne fjerne medlemmer.
04. Den medlemsansvarlige skal kunne sætte et medlems status til passiv/aktiv. 

# IKKE_FUNKTIONELLE KRAV
Systemet skal overholde følgende ikke-funktionelle krav:
01. Databasen skal hostes på en Microsoft SQL Express Server 2019 på din lokale maskine.
02. Backend skal udvikles i C# med Visual Studio 2022.
03. Backend skal være en ASP.NET Core application med .NET 8 som runtime.
04. Backend skal hostes på en IIS Express på din lokale maskine til udvikling.
05. Backend skal til produktion kunne deployes på en Windows Server 2019 maskine på en IIS med .NET 8 som runtime.
06. Alle frontends skal udvikles i HTML5, CSS3 og javascript eller tilsvarende.

07a. Frontend til Event Rating skal designes til og kunne afvikles i en browser på en iOS tablet.

07b. Frontend til Event Rating skal designes til og kunne afvikles i en browser på en Android tablet.

08a. Frontend til medlemshåndtering skal designes til og kunne afvikles i Chrome desktop browser på Windows 10.

08b. Frontend til medlemshåndtering skal designes til og kunne afvikles i Edge desktop browser på Windows 10.

08c. Frontend til medlemshåndtering skal designes til og kunne afvikles i Firefox desktop browser på Windows 10.

09a. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Chrome desktop browser på Windows 10.

09b. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Edge desktop browser på Windows 10.

09c. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Firefox desktop browser på Windows 10.

09d. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Safari mobil browser på iOS.

09e. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Chrome mobil browser på Android.

10a. Kommunikation mellem klient og server skal anvende HTTP eller HTTPS som protokol.

10b. Kommunikation mellem klient og server skal anvende JSON som dataformat.

NOTE: Der skal ikke tages hensyn til sikkerhed, GDPR, kryptering mv., da det ligger uden for fagets mål.