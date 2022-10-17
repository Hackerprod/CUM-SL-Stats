namespace SKYNET.Models
{
    public class Improvement
    {
        public uint ID { get; set; }
        public string ImprovementName { get; set; }
        public string StudentID { get; set; }
        public uint Year { get; set; }
        public Type ImprovementType { get; set; }

        public enum Type
        {
            Diploma,        // Diplomado
            Specialty,      // Especialidad
            Postgraduate,   // Postgrado
            Masters,        // Maestria
            Doctorate       // Doctorado
        }
    }
}
