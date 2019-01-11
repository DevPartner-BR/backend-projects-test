namespace DevpartnerHelper.Functions
{

    /// <summary>
    /// Validadores diversos de documento, números, etc.
    /// </summary>
    public static class Validadores
    {

        /// <summary>
        /// Verifica se o cpnj informado é um número sintaticamente válido
        /// </summary>
        /// <param name="cnpj">Número do cnpj a ser analisado (apenas números)</param>
        /// <returns>Um booleando com o resultado do teste</returns>
        public static bool VerificarCnpj(string cnpj)
        {

            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Invalidar pelo tamanho
            if (cnpj.Length != 14)
                return false;

            int dv;
            string[] peso = { "678923456789", "5678923456789" };

            // Calculando DV1
            dv = 0;
            for (int i = 0; i < 12; i++)
                dv += (int.Parse(cnpj.Substring(i, 1)) * int.Parse(peso[0].Substring(i, 1)));

            dv = (dv % 11);
            if (dv == 10) dv = 0;

            // Validando DV1
            if (dv.ToString() != cnpj.Substring(12, 1))
                return false;

            // Calculando DV2
            dv = 0;
            for (int i = 0; i < 12; i++)
                dv += (int.Parse(cnpj.Substring(i, 1)) * int.Parse(peso[1].Substring(i, 1)));

            dv = (dv % 11);
            if (dv == 10) dv = 0;

            // Validando DV2
            if (dv.ToString() != cnpj.Substring(13, 1))
                return false;

            return true;

        }

    }
}
