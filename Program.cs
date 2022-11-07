//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità.
//Il program.cs si occuperà quindi di gestire tutti i console.writeline/readline mentre le classi di dominio del nostro progetto devono
//occuparsi solo della logica applicativa e fare dei controlli dei dati quando questi violano qualche logica.
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//Non dimentichiamoci però che abbiamo aggiunto la keyword static, quale parametro di quale entità potrebbe essere trasformato in STATIC
//così come abbiamo visto negli esempi?
//Consegna:
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.

Banca intesa = new Banca("Intesa San Paolo");

AggiungiCliente();
AggiungiPrestitoInfo();






void AggiungiCliente()
{
    Console.WriteLine("|------------------------------|");
    Console.WriteLine("Benvenuto in " + intesa.Nome);
    Console.WriteLine("|------------------------------|");
    Console.WriteLine("Inserisci il nome");
    string Nome = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string Cognome = Console.ReadLine();
    Console.WriteLine("Inserisci il Codice Fiscale");
    string CodiceFiscale = Console.ReadLine();
    Console.WriteLine("Inserisci lo Stipendio");
    int Stipendio = Convert.ToInt32(Console.ReadLine());

    if (intesa.AggiungiCliente(Nome, Cognome, CodiceFiscale, Stipendio))
    {
        Console.WriteLine("|------------------------------|");
        Console.WriteLine("Cliente inserito correttamente");
        Console.WriteLine("|------------------------------|");
    }
    else
    {
        Console.WriteLine("|------------------------------|");
        Console.WriteLine("Cliente non inserito, riprova");
        Console.WriteLine("|------------------------------|");
    }
}



string inserisciIlCodiceFiscale()
{
    Console.WriteLine("inserisci il CodiceFiscale");
    string CodiceFiscale = Console.ReadLine();
    return CodiceFiscale;
}

void AggiungiPrestitoInfo()
{
    Cliente ClientePrestito = intesa.RicercaCliente(inserisciIlCodiceFiscale());
    if (ClientePrestito == null)
    {
        Console.WriteLine("Utente non trovato");
        return;
    }
    Console.WriteLine("Inserisci ID");
    int ID = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci ammontare");
    int ammontare = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci rata");
    int rata = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserisci la data fine in formato DD/MM/YYYY: ");
    DateOnly datadifine = DateOnly.Parse(Console.ReadLine());

    Prestito nuovo = new Prestito(ID, ammontare, rata, datadifine, ClientePrestito);

    if (intesa.AggiungiPrestito(nuovo))
    {
        Console.WriteLine("|------------------------------|");
        Console.WriteLine("Prestito inserito correttamente");
        Console.WriteLine("|------------------------------|");
    }
    else
    {
        Console.WriteLine("|------------------------------|");
        Console.WriteLine("Prestito non inserito");
        Console.WriteLine("|------------------------------|");
    }
}
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.
