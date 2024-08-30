namespace BlazorServer.DTO.Response
{
    public class ResponseExample
    {
        public long Id { get; set; }

        public string Nombre { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }

        public bool Estado { get; set; }

    }
}
