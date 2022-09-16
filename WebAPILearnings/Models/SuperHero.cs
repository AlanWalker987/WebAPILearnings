using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPILearnings.Models
{
    public class SuperHero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string SecondName { get; set; } = string.Empty;  

        public string Place { get; set; } = string.Empty;
    }
}
