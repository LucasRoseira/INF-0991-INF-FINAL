internal class Program {
    private static void Main (string[] args) {
        //Exer 1 - Idade para votar. Alteração versão 2
        int year;
        int currentYear, age;
        string currentYearString;

        currentYearString = DateTime.Now.Year.ToString ();
        Console.WriteLine (currentYearString);
        currentYear = Convert.ToInt32 (currentYearString);

        Console.WriteLine ("Digite o ano de nascimento");
        year = Convert.ToInt32 (Console.ReadLine ());

        age = currentYear - year;

        if (age < 16) {
            Console.WriteLine ("Você não pode votar.");
        } else if (age > 15 && age < 18) {
            Console.WriteLine ("Você pode votar.");
        } else {
            Console.WriteLine ("Você precisa votar.");
        }

        //Exer 2 - Maior binário - Alteração versão 3
        String[] numBinaryString = new String[3];
        int[] numBinaryInt = new int[3];

        for (int i = 0; i < 3; i++) {
            Console.WriteLine ("Digite o binário: ");
            numBinaryString[i] = Console.ReadLine ();
            numBinaryInt[i] = Convert.ToInt32 (numBinaryString[i], 2);

            if (i == 2) {
                var intMinimumNum = numBinaryInt.Min ();
                Console.WriteLine ("O menor número é {0}", intMinimumNum);
                var intMaximumNum = numBinaryInt.Max ();
                Console.WriteLine ("O maior número é {0}", intMaximumNum);
            }

        }

        //Exer 3 - Qual é o triângulo
        int[] triangulo = new int[3];
        char lado = 'A';
        for (int i = 0; i < 3; i++) {
            Console.WriteLine ("Por favor, digite o lado  " + (lado++) + ':');
            triangulo[i] = Convert.ToInt32 (Console.ReadLine ());

            if (i == 2) {
                if ((triangulo[0] == triangulo[1]) && triangulo[1] == triangulo[2]) {
                    Console.WriteLine ("Equilátero\n");
                } else if ((triangulo[0] != triangulo[1]) && (triangulo[0] != triangulo[2]) && (triangulo[1] != triangulo[2])) {
                    Console.WriteLine ("Escaleno\n");
                } else
                    Console.WriteLine ("Isósceles\n");
            }
        }
        //Alteração realizada por Raphael, Versão 2.2
    }
    //Versão 3.1
}