using System;
using Enums;
using Services;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryService service = new DirectoryService("C:/");

            Console.WriteLine("Criando Diretório...");
            var code = service.CreateNewDirectory("to");

            if (code == DirectoryStatus.Failed)
            {
                Console.WriteLine("Falha ao criar o diretório.");
                return;
            }

            Console.WriteLine("Copiando Imagens...");
            code = service.CopyImages("from", "to");
            if (code == DirectoryStatus.Inexistent)
            {
                Console.WriteLine("Verifique se os diretórios informados existem.");
                return;
            } else if (code == DirectoryStatus.Failed) {
                Console.WriteLine("Falha ao copiar as imagens.");
                return;
            }

            Console.WriteLine("Arquivos copiados com sucesso.");
        }
    }
}
