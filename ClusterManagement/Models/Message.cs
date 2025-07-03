namespace ClusterManagement.Models;
/// <summary>
/// En melding som sendes mellom brukere eller systemer
/// /// Inneholder informasjon om avsender, mottaker, innhold og tidspunkt
public class Message
{
    public Message(Guid from, Guid to, Guid about, string content)
    {
        From = from;
        To = to;
        About = about;
        Content = content;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Innholdet i meldingen. Det noen vil "si" til noen andre
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// Guid-en til avsenderen
    /// </summary>
    /// <remarks>
    /// Kan være en Cluster eller en ClusterUser, eller kanskje noe annet
    /// lurt dere lager, men dere må være konsekvente!
    /// </remarks>
    public Guid From { get; set; }
    /// <summary>
    /// Guid-en til mottakeren
    /// </summary>
    /// <remarks>
    /// Kan være en Cluster eller en ClusterUser, eller kanskje noe annet
    /// lurt dere lager, men dere må være konsekvente!
    /// </remarks>
    public Guid To { get; set; }
    /// <summary>
    /// Guid-en til OneWayOpportunity-en som meldingen handler om
    /// </summary>
    /// <remarks>
    /// Dette feltet kan brukes til å knytte meldingen til en spesifikk
    /// OneWayOpportunity
    /// </remarks>
    public Guid About { get; set; }
    /// <summary>
    /// Tidspunktet meldingen ble sendt
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

}
