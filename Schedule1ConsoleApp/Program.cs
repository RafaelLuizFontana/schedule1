// See https://aka.ms/new-console-template for more information
using Schedule1ConsoleApp.Model;
using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Ingredient;
using Schedule1ConsoleApp.Model.Interface;

List<IIngredient> ingredients;
List<GenericMix> mixes;
IBaseDrug drug;
int iterations;
InitApp();
Console.WriteLine("Welcome to the Schedule 1 Console App!");
bool selectDrug = true;
while (selectDrug)
{
    bool drugSelected = true;
    Console.WriteLine("Please select a drug type to start the mix:");
    Console.WriteLine("");
    Console.WriteLine("1 - OG Kush ($38)");
    Console.WriteLine("2 - Sour Diesel ($40)");
    Console.WriteLine("3 - Green Crack ($43)");
    Console.WriteLine("4 - Granddaddy Purple ($44)");
    Console.WriteLine("5 - Methamphetamine ($70)");
    Console.WriteLine("6 - Cocaine ($150)");
    Console.WriteLine("0 - Exit App");
    Console.WriteLine("");

    string? input = Console.ReadLine();

    if (input == "0") break;
    switch (input)
    {
        case "1":
            Console.WriteLine("You selected OG Kush.");
            break;
        case "2":
            Console.WriteLine("You selected Sour Diesel.");
            drug = new SourDiesel();
            break;
        case "3":
            Console.WriteLine("You selected Green Crack.");
            drug = new GreenCrack();
            break;
        case "4":
            Console.WriteLine("You selected Granddaddy Purple.");
            drug = new GranddaddyPurple();
            break;
        case "5":
            Console.WriteLine("You selected Methamphetamine.");
            drug = new Meth();
            break;
        case "6":
            Console.WriteLine("You selected Cocaine.");
            drug = new Coke();
            break;
        default:
            Console.WriteLine("Invalid selection");
            Console.WriteLine("");
            drugSelected = false;
            break;
    }
    if (drugSelected) {
        bool selectNumberOfMixes = true;
        Console.WriteLine("");
        Console.WriteLine("Please select a number of mixes you want (or 0 to exit):");
        Console.WriteLine("");

        while (selectNumberOfMixes){
            input = Console.ReadLine();
            int mixNumber;
            if (int.TryParse(input, out int numberOfMixes) && numberOfMixes > 0)
            {
                mixNumber = numberOfMixes;
                Console.WriteLine($"You selected {mixNumber} mix(es).");
                Console.WriteLine("");
                FirstMix();
                mixNumber--;
                while(mixNumber-- > 0){
                    Mix();
                }
                Console.WriteLine($"Unique mixes found: {iterations}");
                GenericMix maxValueMix = mixes.MaxBy(x => x.Profit());
                Console.WriteLine("Best mix:");
                Console.WriteLine($"{maxValueMix.BaseDrug().Name()} with:");
                foreach(IIngredient ingredient in maxValueMix.Ingredients()){
                    Console.WriteLine($"--> {ingredient.Name()} ({Math.Round(ingredient.Cost())}$)");
                }
                Console.WriteLine("Effects:");
                foreach(EffectListItem effect in maxValueMix.Effects().GetEffects()){
                    Console.WriteLine($"{effect.Effect.Name()}");
                }
                Console.WriteLine("-------------");
                Console.WriteLine($"Value:  {Math.Round(maxValueMix.Value())}$");
                Console.WriteLine($"Cost:   {Math.Round(maxValueMix.Cost())}$");
                Console.WriteLine($"Profit: {Math.Round(maxValueMix.Profit())}$");
                Console.WriteLine("");
                bool enterYesNo = true;
                Console.WriteLine("Continue mixing? (y/n)");
                while (enterYesNo){
                    string? continueInput = Console.ReadLine();
                    if (continueInput == "y" || continueInput == "Y")
                    {
                        InitApp();
                        enterYesNo = false;
                        selectNumberOfMixes = false;
                    }
                    else if (continueInput == "n" || continueInput == "N")
                    {
                        enterYesNo = false;
                        selectNumberOfMixes = false;
                        selectDrug = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    }
                }
            }
            else if (input == "0")
            {
                selectNumberOfMixes = false;
                selectDrug = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number or 0 to exit.");
            }
        }
    }
}

void FirstMix(){
    Parallel.ForEach(ingredients, ingredient =>{
        GenericMix mix = new(drug);
        mix.AddIngredient(ingredient);
        mixes.Add(mix);
        iterations++;
    });
}

void Mix(){
    List<GenericMix> newMixes = [];
    Parallel.ForEach(ingredients, ingredient =>{
        Parallel.ForEach(mixes, mix =>{
            GenericMix genericMix = new (mix);
            genericMix.AddIngredient(ingredient);
            if(!mixes.Any(x => x.Equals(genericMix))){
                newMixes.Add(genericMix);
                iterations++;
            }
        });
    });
    mixes = newMixes;
}

void InitApp(){
    ingredients =
[
    new Addy(),
    new Banana(),
    new Battery(),
    new Chili(),
    new Cuke(),
    new Donut(),
    new EnergyDrink(),
    new FluMedicine(),
    new Gasoline(),
    new HorseSemen(),
    new Iodine(),
    new MegaBean(),
    new MotorOil(),
    new MouthWash(),
    new Paracetamol(),
    new Viagor(),
];
mixes = [];
drug = new OGKush();
iterations = 0;
}
