namespace src.Models;

public class Person
{
    public Person()
    {
        this.Name = "";
        this.Age = 0;
        this.Ativado = true;
        this.Contracts = new List<Contract>();
    }
 
    public Person(string Name, int Age, string Cpf)
    {
        this.Name = Name;
        this.Age = Age;
        this.Cpf = Cpf;
        this.Ativado = true;
        this.Contracts = new List<Contract>();
    }

    // Id
    public int Id { get; set; }
    
    // Nome
    public string Name { get; set; }

    // Idade
    public int Age { get; set; }

    // Cpf
    public string? Cpf { get ; set; }

    // Status
    public bool Ativado { get; set; }

    public List<Contract> Contracts { get; set; }
    
}