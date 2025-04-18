using Web_API_Stamps.Models;

namespace API_upload.Models
{
    public class Stamp
    {
        public int Id { get; set; }

        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? FilePath { get; set; }  // Optional: if you add a FilePath
        public DateTime? UploadedAt { get; set; }

      //  public byte[]? FileData { get; set; }  // Binary data column (VARBINARY)

        public string? StampName { get; set; }
        public string? Country { get; set; }
        public int? YearOfIssue { get; set; }
        public string? CatalogNumber { get; set; }

        public string? Condition { get; set; }
        public string? Watermark { get; set; }
        public string? Size { get; set; }
        public string? FaceValue { get; set; }

        public string? Color { get; set; }
        public string? PrintMethod { get; set; }
        public string? Rarity { get; set; }
        public string? SpecialFeatures { get; set; }

        public string? StampSeries { get; set; }
        public string? HistoricalSignificance { get; set; }
        public string? Provenance { get; set; }
        public string? AdditionalNotes { get; set; }

        public string? ThumbnailDataBase64 { get; set; }

        public StampCategory StampCategory { get; set; }  

        //public ImageData? ImageData { get; set; }
        //public ThumbnailData? ThumbnailData { get; set; }

    }

    /*
    1. Stempelnavn eller Titel
Beskrivelse: Navnet på stemplet eller titlen, hvis det er en del af en serie.

Eksempel: "Britisk Penny Black (1840)"

2. Ursprungsland
Beskrivelse: Det land, hvor stemplet blev udstedt.

Eksempel: "Storbritannien," "USA"

3. Udstedelsesår
Beskrivelse: Året, hvor stemplet blev udgivet.

Eksempel: "1840" for Penny Black.

4. Katalognummer
Beskrivelse: Katalognummeret, f.eks.fra Scott, Stanley Gibbons eller Michel katalogsystemerne.

Eksempel: "Scott #1" for den første udgivelse fra USA.

5. Tilstand/Grad
Beskrivelse: Den fysiske tilstand af stemplet (f.eks.ubrugte, brugte, perforeringer).

Eksempel: "Ubrugt, med hængsel," "Brugt, God," "Afstemplede"

6. Vandmærke
Beskrivelse: Eventuelle vandmærker, der er til stede på stemplet, som kan hjælpe med at identificere sjældne eller værdifulde frimærker.

Eksempel: "Ingen," "Kronemærke"

7. Størrelse (Dimensioner)
Beskrivelse: Den fysiske størrelse af stemplet, enten i mm eller tommer.

Eksempel: "25mm x 30mm"

8. Pålydende værdi (Denomination)
Beskrivelse: Den pålydende værdi eller denomination af stemplet.

Eksempel: "1 cent," "10 shillings"

9. Farve(r)
Beskrivelse: De primære farver på stemplet.Nogle frimærker er kendt for deres unikke farvevariationer.

Eksempel: "Sort," "Rød og Blå"

10. Trykmetode
Beskrivelse: Trykmetoden, der blev brugt (f.eks.litografi, gravering).

Eksempel: "Litografi," "Gravering"

11. Sjældenhed
Beskrivelse: Frimærkets sjældenhed, hvilket kan påvirke dets værdi.

Eksempel: "Almindelig," "Sjælden," "Unik"

12. Særlige funktioner
Beskrivelse: Eventuelle unikke eller interessante funktioner (f.eks.fejltryk, trykfejl, perforeringsproblemer).

Eksempel: "Omvendt Center," "Farvefejl"

13. Stempelserie
Beskrivelse: Hvis stemplet er en del af en større serie eller samling, kan serienavnet hjælpe med at organisere samlingen.

Eksempel: "Dronningens Portræt Serie"

14. Historisk betydning
Beskrivelse: Eventuelle historiske begivenheder knyttet til stemplet, som f.eks.jubilæer eller vigtige datoer.

Eksempel: "100-års jubilæum for Postvæsenet," "Verdenskrig II Memorial"

15. Proveniens (Ejerhistorik)
Beskrivelse: Oplysninger om stemplets ejerhistorik, især hvis det har været en del af en berømt samling eller har en veldokumenteret historie.

Eksempel: "Ex. John Smith Collection"

16. Upload dato
Beskrivelse: Datoen, hvor billedet blev uploadet.

Eksempel: "2025-04-07"

17. Yderligere bemærkninger/Kommentarer
    Beskrivelse: Eventuelle ekstra oplysninger, der kunne være nyttige for ejeren eller potentielle købere. Dette kan inkludere bemærkninger om stemplets tilstand, historie eller betydning i samlingen.

Eksempel: "Lille fold i nederste venstre hjørne," "Autograferet af designeren"
*/
}
