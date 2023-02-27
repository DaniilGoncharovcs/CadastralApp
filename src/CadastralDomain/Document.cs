namespace CadastralDomain;

public class Document
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Название документа обязательно для заполнения")]
    [MaxLength(100, ErrorMessage = "Максимальная длина названия документа - 100 символов")]
    public string Name { get; set; }
}