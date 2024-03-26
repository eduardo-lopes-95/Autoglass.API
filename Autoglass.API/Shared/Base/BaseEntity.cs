namespace Autoglass.API.Shared.Base;

/// <summary>
/// Classe base para todas as entidades do sistema.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Obtém ou define o identificador único da entidade.
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define a data e hora em que a entidade foi criada.
    /// </summary>
    /// <example>2024-03-26T08:30:00</example>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Obtém ou define a data e hora da última modificação na entidade.
    /// </summary>
    /// <example>2024-03-26T08:30:00</example>
    public DateTime ModifiedDate { get; set; }
}
