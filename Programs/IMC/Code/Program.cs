using System;

namespace Apex {

   class CalculoImc {

       static void Main() {

        decimal peso = 0;
        decimal altura = 0;

        Console.WriteLine(“Digite seu peso:”);
        peso = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine(“Digite sua altura:”);
        altura = Convert.ToDecimal(Console.ReadLine());

        var resultado = pessoa / (altura * altura);

        Console.WriteLine(“Seu IMC é:” + resultado);
        Console.WriteLine(“Pressione qualquer tecla para sair.”);

        Console.ReadKey();

       }
   }
}