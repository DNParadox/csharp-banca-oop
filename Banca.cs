//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità.
//Il program.cs si occuperà quindi di gestire tutti i console.writeline/readline mentre le classi di dominio del nostro progetto devono
//occuparsi solo della logica applicativa e fare dei controlli dei dati quando questi violano qualche logica.
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//Non dimentichiamoci però che abbiamo aggiunto la keyword static, quale parametro di quale entità potrebbe essere trasformato in STATIC
//così come abbiamo visto negli esempi?
//Consegna:
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.





//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)

public class Banca
{
    public string Nome { get; set; }
    List<Cliente> Clienti { get; set; }

    List<Prestito> Prestiti { get; set; }

    public Banca(string Nome)
    {
        Nome = Nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();
    }

    public bool AggiungiCliente(Cliente cliente)
    {
        //if (
        //   cliente.Nome == null || cliente.Nome == "" ||
        //   cliente.Cognome == null || cliente.Cognome == "" ||
        //   codiceFiscale == null || codiceFiscale == "" ||
        //   stipendio < 0
        //   )
        //{
        //    return false;
        //}

        return false;
    }

    public bool AggiungiCliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        if (
            nome == null || nome == "" ||
            cognome == null || cognome == "" ||
            codiceFiscale == null || codiceFiscale == "" ||
            stipendio < 0
            )
        {
            return false;
        }

        Cliente esistente = RicercaCliente(codiceFiscale);

        //se il cliente esiste l'istanza sarà diversa dal null
        if (esistente != null)
            return false;

        Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        Clienti.Add(cliente);

       
        return true;
    }

    public void ModificaCliente(Cliente cliente)
    {
        Console.WriteLine("Inserisci il nome");
        string Nome = Console.ReadLine();
        if (Nome != "")
        {
            cliente.Nome = Nome;
        }

        Console.WriteLine("Inserisci il Cognome");
        string Cognome = Console.ReadLine();

        if (Cognome != "")
        {
            cliente.Cognome = Cognome;
        }

        Console.WriteLine("Inserisci il Codice Fiscale");
        string CodiceFiscale = Console.ReadLine();

        if (CodiceFiscale != "")
        {
            cliente.CodiceFiscale = CodiceFiscale;
        }

        Console.WriteLine("Inserisci lo Stipendio");
        int Stipendio = Convert.ToInt32(Console.ReadLine());

        if (Stipendio > 200)
        {
            cliente.Stipendio = Convert.ToInt32(Console.ReadLine());
        }
    }

    public Cliente RicercaCliente(string codiceFiscale)
    {

        foreach (Cliente cliente in Clienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }

        return null;
    }

    public List<Prestito> RicercaPrestito(string codiceFiscale)
    {
        List<Prestito> trovati = new List<Prestito>();



        return trovati;
    }

    public int AmmontareTotalePrestitiCliente(string codiceFiscale)
    {
        int ammontare = 0; //metterò il conteggio

        //conteggio...

        return ammontare;
    }

    public int RateMancantiCliente(string codiceFiscale)
    {
        int rateMancanti = 0; //metterò il conteggio

        //conteggio...

        return rateMancanti;
    }

  

    public bool AggiungiPrestito(Prestito nuovoPrestito)
    {
        if (
           nuovoPrestito.ID == null || nuovoPrestito.ID < 0 ||
           nuovoPrestito.Intestatario == null ||
           nuovoPrestito.Ammontare == null || nuovoPrestito.Ammontare < 0 ||
           nuovoPrestito.ValoreRata == null || nuovoPrestito.ValoreRata < 0 ||
           nuovoPrestito.Fine == null
           )
        {
            return false;
        }
        else
        {
            if ((nuovoPrestito.Intestatario.Stipendio / 2) > ControlloPrestito(nuovoPrestito.Intestatario.CodiceFiscale))
            {
                Prestiti.Add(nuovoPrestito);
                return true;
            }

            return false;
        }
    }


    public int ControlloPrestito(string codiceFiscale)
    {
        List<Prestito> PrestitiAlCliente = PrestitiConcessiCliente(codiceFiscale);
        int totalAmount = 0;

        foreach (Prestito prestito in PrestitiAlCliente)
        {
            totalAmount += prestito.ValoreRata;
        }

        return totalAmount;
    }

    public List<Prestito> PrestitiConcessiCliente(string codiceFiscale)
    {
        Cliente esistente = RicercaCliente(codiceFiscale);
        List<Prestito> PrestitiAlCliente = new List<Prestito>();
        if (esistente != null)
        {
            foreach (Prestito prestito in Prestiti)
            {
                if (prestito.Intestatario.CodiceFiscale == esistente.CodiceFiscale)
                {
                    PrestitiAlCliente.Add(prestito);
                }
            }
        }

        return PrestitiAlCliente;
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
