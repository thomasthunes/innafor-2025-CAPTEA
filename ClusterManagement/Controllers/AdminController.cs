using ClusterManagement.Models;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class AdminController 
{
    private readonly ClusterContext _context;
    public AdminController(ClusterContext context)
    {
        _context = context;
    }
    [HttpPost]
    public Task Seed()
    {
        _context.Clusters.RemoveRange(_context.Clusters);
        _context.ClusterUsers.RemoveRange(_context.ClusterUsers);
        _context.OneWayInOpportunities.RemoveRange(_context.OneWayInOpportunities);
        _context.Messages.RemoveRange(_context.Messages);
        //patent kontor?
        //gjær spesialist
        //gravemaskin ekspert
        var cluster1 = new Cluster
        {
            Name = "Vestlands Business Akademi",
            EmailAddress = "postboks@vba.no",
            Telephone = "12345678",
            WebsiteUrl = "https://www.vba.no",
            OrganizationNumber = "123456789",
            IndustryCode = "1234",
            ClusterPurpose = "To promote business education in the Vestland region.",
            ClusterVision = "To be the leading business academy in Vestland.",
            DateOfFoundation = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            MainContact = null
        };
        var cluster2 = new Cluster
        {
            Name = "Nordic Innovation Hub",
            EmailAddress = "hei@nordicinnovation.no",
            Telephone = "87654321",
            WebsiteUrl = "https://www.nordicinnovation.no",
            OrganizationNumber = "987654321",
            IndustryCode = "5678",
            ClusterPurpose = "To foster innovation across the Nordic countries.",
            ClusterVision = "To be the catalyst for innovation in the Nordics.",
            DateOfFoundation = new DateTime(2010, 5, 15, 0, 0, 0, DateTimeKind.Utc),
            MainContact = null
        };
        var cluster3 = new Cluster
        {
            Name = "Tech Innovators",
            EmailAddress = "tech@techinnovators.no",
            Telephone = "11223344",
            WebsiteUrl = "https://www.techinnovators.no",
            OrganizationNumber = "112233445",
            IndustryCode = "9101",
            ClusterPurpose = "To drive technological advancements in Norway.",
            ClusterVision = "To be the leading tech cluster in Norway.",
            DateOfFoundation = new DateTime(2010, 5, 15, 0, 0, 0, DateTimeKind.Utc),
            MainContact = null
        };
        var cluster4 = new Cluster
        {
            Name = "Green Energy Alliance",
            EmailAddress = "kontakt@green_energy.no",
            Telephone = "55667788",
            WebsiteUrl = "https://www.greenenergy.no",
            OrganizationNumber = "223344556",
            IndustryCode = "1213",
            ClusterPurpose = "To promote sustainable energy solutions.",
            ClusterVision = "To lead the transition to green energy in Norway.",
            DateOfFoundation = new DateTime(2010, 5, 15, 0, 0, 0, DateTimeKind.Utc),
            MainContact = null,
        };
        _context.Clusters.AddRange(cluster1, cluster2, cluster3, cluster4);
        _context.SaveChanges();
        _context.Entry<Cluster>(cluster1).Reload();
        _context.Entry<Cluster>(cluster2).Reload();
        _context.Entry<Cluster>(cluster3).Reload();
        _context.Entry<Cluster>(cluster4).Reload();
        var vbaClusterUser1 = new ClusterUser
        {
            Cluster = cluster1,
            FirstName = "Ola",
            LastName = "Nordmann",
            EmailAddress = String.Format("ola.normann@vba.no"),
            Phone = "12345678",
            Responsibilities = "Accountant",
        };
        var vbaClusterUser2 = new ClusterUser
        {
            Cluster = cluster1,
            FirstName = "Kalle",
            LastName = "Pedersen",
            EmailAddress = String.Format("kalle.pedersen@.vba.no"),
            Phone = "23456789",
            Responsibilities = "Business Development Manager",
        };
        var vbaClusterUser3 = new ClusterUser
        {
            Cluster = cluster1,
            FirstName = "Steinar",
            LastName = "Johansen",
            EmailAddress = String.Format("steinar.johansen" + "@vba.no"),
            Phone = "34567890",
            Responsibilities = "Chief Executive Officer",
        };
        var nordicinnovationUser1 = new ClusterUser
        {
            Cluster = cluster2,
            FirstName = "Kari",
            LastName = "Nordmann",
            EmailAddress = String.Format("kari.nordmann@nordicinnovation.no"),
            Phone = "87654321",
            Responsibilities = "Marketing Manager",
        };
        var nordicinnovationUser2 = new ClusterUser
        {
            Cluster = cluster2,
            FirstName = "Erik",
            LastName = "Svensen",
            EmailAddress = String.Format("erik.svenson@nordicinnovation.no"),
            Phone = "98765432",
            Responsibilities = "Project Manager",
        };
        var nordicinnovationUser3 = new ClusterUser
        {
            Cluster = cluster2,
            FirstName = "Lise",
            LastName = "Hansen",
            EmailAddress = String.Format("lise.hansen@nordicinnovation.no"),
            Phone = "12345678",
            Responsibilities = "Innovation Specialist",
        };
        var clusterUser3 = new ClusterUser
        {
            Cluster = cluster3,
            FirstName = "Per",
            LastName = "Hansen",
            EmailAddress = String.Format("ph@techinnovators.no"),
            Phone = "11223344",
            Responsibilities = "Chief Technology Officer",
        };
        var clusterUser4 = new ClusterUser
        {
            Cluster = cluster4,
            FirstName = "Anna",
            LastName = "Svensson",
            EmailAddress = String.Format("a.svenson@green_energy.no"),
            Phone = "55667788",
            Responsibilities = "Sustainability Officer",
        };
        cluster1.MainContact = vbaClusterUser3.Id;
        cluster2.MainContact = nordicinnovationUser3.Id;
        cluster3.MainContact = clusterUser3.Id;
        cluster4.MainContact = clusterUser4.Id;
        
        // joga med geiter
        //klesapponement
        //Ar briller får det til å se ut som det er tomt på bussen
        //beskyttelse mot 
        // 
        // Hjemmemanikyr og pedikyr 
        // paraply as a service paraply
        // slkrem as a service
        // varmt fra jobb jakkehotell? bysykkel
        // 
        var oneWayInOpportunity1 = new OneWayInOpportunity
        {
            Cluster = cluster1,
            Title = "Grusomaten",
            Description = "Har du noen gang gått tom for grus? Og alt du har er stor stein? Grusomaten er verktøyet for deg! Grusomaten tar inn en stor stein, og gjennom vårt pattenterte steindunkesystem, dunker vi steinen til det bare er grus igen. Hva du bruker grusen til, er opp til deg!  Vi ønsker å bringe grusomaten vår til et større marked in norge",
            IsClosed = false,
            CustomerName = "Big Stein AS",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = vbaClusterUser1,
        };
        var oneWayInOpportunity2 = new OneWayInOpportunity
        {
            Cluster = cluster2,
            Title = "En strømapp med strømpriser fra hele verden",
            Description = "Har du noen gang lurt på hva strømprisene er i andre land? Vi har utviklet en app som gir deg sanntidsdata om strømpriser fra hele verden. Dette vil hjelpe brukere å sammenligne priser og finne de beste tilbudene.",
            IsClosed = false,
            CustomerName = "Global Energy Solutions",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = nordicinnovationUser1,
        };
        var oneWayInOpportunity3 = new OneWayInOpportunity
        {
            Cluster = cluster3,
            Title = "AI-drevet kundeservice",
            Description = "Vi har utviklet en AI-løsning som kan håndtere kundeservicehenvendelser automatisk. Løsningen vil uansett hva slags spørsmål kunden har, svare ut at det ikke er noe vi kan hjelpe dem med. Dette vil redusere ventetiden for kundene og frigjøre ressurser for selskapet.",
            IsClosed = false,
            CustomerName = "Dnb",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = clusterUser3,
        };
        var oneWayInOpportunity4 = new OneWayInOpportunity
        {
            Cluster = cluster4,
            Title = "Grønn energilagring",
            Description = "Vi har utviklet en ny teknologi for energilagring som er både effektiv og miljøvennlig. Dette vil bidra til å redusere karbonavtrykket og fremme bærekraftig energi.",
            IsClosed = false,
            CustomerName = "Eco Energy Solutions",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = clusterUser4,
        };
        var oneWayInOpportunity5 = new OneWayInOpportunity
        {
            Cluster = cluster1,
            Title = "Grusomaten 2.0",
            Description = "Vi har utviklet en ny og forbedret versjon av Grusomaten, som kan håndtere større steiner og produsere mer grus på kortere tid.",
            IsClosed = false,
            CustomerName = "Big Stein AS",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = vbaClusterUser2,
        };
        var OneWayInOpportunity6 = new OneWayInOpportunity
        {
            Cluster = cluster2,
            Title = "Surdeigsbakeri i Kristiansand",
            Description = "Vi har startet et nytt surdeigsbakeri i Kristiansand, og vi ønsker å samarbeide med andre aktører for å utvide vår distribusjon.",
            IsClosed = false,
            CustomerName = "Kristiansand Surdeigsbakeri",
            SubmittedOn = DateTime.UtcNow,
            LastChangedOn = DateTime.UtcNow,
            AssignedTo = nordicinnovationUser2,
        };

        _context.ClusterUsers.AddRange(
            vbaClusterUser1, vbaClusterUser2, vbaClusterUser3,
            nordicinnovationUser1, nordicinnovationUser2, nordicinnovationUser3,
            clusterUser3, clusterUser4
        );
        _context.OneWayInOpportunities.AddRange(
            oneWayInOpportunity1, oneWayInOpportunity2, oneWayInOpportunity3,
            oneWayInOpportunity4, oneWayInOpportunity5, OneWayInOpportunity6
        );
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}
