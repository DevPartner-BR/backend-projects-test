namespace WebAPI.Models
{
    public abstract class GenericResponse<T> where T: class
    {

        /// <summary>
        /// Flag indicando o sucesso ou falha da operação
        /// </summary>
        public bool Sucesso { get; set; }

        /// <summary>
        /// Objeto/Mensagem de resultado da operação
        /// </summary>
        public T Mensagem { get; set; }

    }
}