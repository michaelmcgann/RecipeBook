namespace RecipeApp;

public class Ingredient {
    
    public string Name { get; set; }
    public int Id { get; set; }
    public string Instructions { get; set; }

    public Ingredient(string name, int id, string instructions) {
        Name = name;
        Id = id;
        Instructions = instructions;
    }
    
    public override bool Equals(object? obj) {
        if (obj is Ingredient other) {
            return this.Id == other.Id &&
                   this.Name == other.Name &&
                   this.Instructions == other.Instructions;
        }
        return false;
    }
    
    public override int GetHashCode() {
        return HashCode.Combine(Id, Name, Instructions);
    }

}