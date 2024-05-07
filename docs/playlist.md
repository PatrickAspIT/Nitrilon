# PLAYLISTE TIL EKSAMEN

1. Præsenter casen (fordi så viser man at man har forstået hvad man skal lave). Det vil sige at man kort beskriver systemets ønskede funktionalitet aka. systembeskrivelsen.

2. Præsentation af systemudviklingsværktøjer, herunder systemudviklingsmetoden og projektstyringen.
    - Systemudviklingsmetoden: Agil og iterativ, inception, elaboration, construction, testing. Hvad er formålet med hver af disse?

        01. Agil: Være fleksibel og arbjede i korte iterationer, for at lave 1 funktion ad gangen.
        02. Iterativ: Bygge og forbedre systemet gradvist igennem udvikling og evaluering.
        03. Inception: Skabe et kravspec. og find entiteter. Lav analyse diagrammer.
        04. Elaboration: Lav design diagrammer, sæt op Github Projects og start med at lave issues gradvist.

    - Inception: Hvordan har man lavet kravspec? Hvad er et godt krav?

        01. Klart og præcist: Let forståeligt så man ikke er i tvivl om, hvad der kræves. Undgå unødvendig kompleksitet.
        02. Målbart: Muligt at måle, hvornår kravet er opfyldt. 
        03. Opnåeligt: Realistisk inden for projektets rammer (tid, budget og ressourcer).

    - Elaboration: Hvordan kommer man fra Inception til Elaboration? Vi anvendte værktøjerne:
        - "Find navneord" => Entiteter/Aktører
        - Lavede analyse diagrammer (ER), hvad er relationerne mellem entiteterne.
        - Bagefter lavede vi design diagrammer, ER og UML.
    - Projekstyring på GitHub: Vis github projektet og issues.

3. Begynd at vise hvordan UI virker ift. de funktionelle krav.

    01. requirements-specification.md dokument.

4. Construction: 
    * Hvad er et klient-server system?

        01. Frontend: Hjemmeside (HTML, CSS, JS).
        02. Backend: Nitrilon.Api (Database, Controllers...).

    * UI/UX kode, hvordan kommunikerer klienten med serveren? HTTP metoderne og JSON.

        01. JavaScript filerne kommunikerer med HTTP metoderne (f.eks. GET, POST, PUT, DELETE).

    * Arkitektur med Separation of Concerns: Modulær opbygning med klassebiblioteker og applikationer.
    * API: endpoint (IP + port) og IIS'ens rolle
        * Controllere og deres action methods, herunder URI'en
    * Data Access: Repository design pattern.
    * Database: SQL + tabeller, kolonner, rækker, PK, FK.

        01. SQL: Sprog til at interagere med databaser (SELECT, INSERT, UPDATE, DELETE).
        02. Tabeller: F.eks. EventRating.
        03. Kolonner: ↓ Attributter som viser de forskellige data i tabellen samt. datatype.
        04. Rækker: En enkelt attribute med alle dens egenskaber.
        05. PK: Primærnøgle, unik.
        06. FK: Fremmednøgle, data fra anden tabel.

    * OOP:
        * Indkapsling: Hvad er formålet og hvordan anvender man det? Eks.: Entities.

            01. Indkapsling: Skjule detaljer og kun give adgang igennem veldefinerede grænseflader. Bedre kontrol over hvordan data manipuleres.

        * Komposition/Aggregation: Hvad er formålet og hvordan anvender man det? Eks.: Entities.

            02. Komposition: Objekter er afhængelige af hinanden. Hvis det overordnede objekt bliver slettet, bliver det underordnede objekt også slettet.
            03. Aggregation: Objekter er uafhængelige af hinanden. Det overlagte objekt har kun en refference til det underordnede objekt, ike dens helhed.

        * Arv: Hvad er formålet og hvordan anvender man det? Eks.: DataAccess.

            04. Arv: Genbruge og overskrive metoder fra overklassen. Hvis du har en masse klasser som gør noget lignende, så kan man lave en masterclass som gør det den skal og så returerer en værdi.
    
## Hvad vi mangler...
 01. Giv mulighed for den EventAnsvarlige at oprette nyt event på hjemmesiden.
 02. Giv procentdel af bedømmelserne under rating-siden.