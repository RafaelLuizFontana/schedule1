// See https://aka.ms/new-console-template for more information
using Schedule1ConsoleApp.Model;
using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.DrugType;
using Schedule1ConsoleApp.Model.Ingredient;
using Schedule1ConsoleApp.Model.Interface;

List<IIngredient> ingredients;
List<GenericMix> mixes;
IBaseDrug drug;
List<IEffect> effects = [];
int iterations;
string? input;
InitApp();
Console.WriteLine("Welcome to the Schedule 1 Console App!");
bool selectNumberOfMixes = true;
bool selectDrug = true;
bool enterYesNo = true;
bool findMixSelected = false;
bool doneSelecting = false;
int mixNumber;
SelectDrugMenu();

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

void SelectDrugMenu(){
    while (selectDrug)
    {
        bool drugSelected = true;
        Console.WriteLine("Please select a drug type to start or type 9 to find a mix:");
        Console.WriteLine("");
        Console.WriteLine("1 - OG Kush ($38)");
        Console.WriteLine("2 - Sour Diesel ($40)");
        Console.WriteLine("3 - Green Crack ($43)");
        Console.WriteLine("4 - Granddaddy Purple ($44)");
        Console.WriteLine("5 - Methamphetamine ($70)");
        Console.WriteLine("6 - Cocaine ($150)");
        Console.WriteLine("9 - Find mix");
        Console.WriteLine("0 - Exit App");
        Console.WriteLine("");

        input = Console.ReadLine();

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
            case "9":
                Console.WriteLine("You selected Find mix.");
                findMixSelected = true;
                drugSelected = false;
                break;
            default:
                Console.WriteLine("Invalid selection");
                Console.WriteLine("");
                drugSelected = false;
                findMixSelected = false;
                break;
        }
        if (drugSelected) {
            Console.WriteLine("");
            Console.WriteLine("Please select a number of mixes you want (or 0 to exit):");
            Console.WriteLine("");
            SelectNumberOfMixesMenu();
        }
        if (findMixSelected){
            FindMixMenu();
        }
    }
}

void SelectNumberOfMixesMenu(){
    while (selectNumberOfMixes){
        input = Console.ReadLine();
        if (int.TryParse(input, out int numberOfMixes) && numberOfMixes > 0)
        {
            StartMixing(numberOfMixes);
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

void ContinueMenu(){
    Console.WriteLine("Continue mixing? (y/n)");
    while (enterYesNo){
        input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            InitApp();
            enterYesNo = false;
            selectNumberOfMixes = false;
        }
        else if (input == "n" || input == "N")
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

void StartMixing(int numberOfMixes){
    mixNumber = numberOfMixes;
    Console.WriteLine($"You selected {mixNumber} " + (mixNumber == 1 ? "mix." : "mixes."));
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
    ContinueMenu();
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

void FindMixMenu(){
    EffectList effectList = new();
    while(!doneSelecting){
        List<IEffect> effectsToSelect = InitEffects();
        Console.WriteLine("");
        Console.WriteLine("Please select the desired effect:");
        Console.WriteLine("");
        for (int i = 0; i<effectsToSelect.Count; i++){
            if(!effectList.HasEffect(effectsToSelect[i]))Console.Write($"{i+1} - {effectsToSelect[i].Name()} ");
        }
        Console.WriteLine("");
        input = Console.ReadLine();
        if(input == "0"){
            selectNumberOfMixes = false;
            selectDrug = false;
            doneSelecting = true;
        }else if(int.TryParse(input, out int index) && index - 1 < 34 && !effectList.HasEffect(effectsToSelect[index-1])){
            Console.WriteLine($"You selected {effectsToSelect[index-1].Name()}");
            effectList.SetEffect(effectsToSelect[index-1]);
            Console.WriteLine("");
            Console.WriteLine("Continue selecting? (y/n)");
            while (enterYesNo){
                input = Console.ReadLine();
                if (input == "y" || input == "Y"){
                    enterYesNo = false;

                }else if (input == "n" || input == "N")
                {
                    findMixSelected = true;
                    enterYesNo = false;
                    FindMix(effectList);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
            enterYesNo = true;
        } else {
            Console.WriteLine("Invalid input. Please enter a positive number or 0 to exit.");
        }
    }
}

void FindMix(EffectList effectList){
    //drug = new OGKush();
    //drug = new SourDiesel();
    //drug = new GreenCrack();
    //drug = new GranddaddyPurple();
    drug = new Meth();
    //drug = new Coke();
    FirstMix();
    bool found = false;
    while(!found){
        List<GenericMix> newMixes = [];
        Parallel.ForEach(ingredients, ingredient =>{
            Parallel.ForEach(mixes, mix =>{
                GenericMix genericMix = new (mix);
                genericMix.AddIngredient(ingredient);
                foreach(EffectListItem effectListItem in effectList.GetEffects()){
                    if(!genericMix.Effects().HasEffect(effectListItem.Effect)) {    
                        if(!mixes.Any(x => x.Equals(genericMix))){
                            newMixes.Add(genericMix);
                        }
                        return;
                    }
                }
                Console.WriteLine("Mix found:");
                Console.WriteLine($"{genericMix.BaseDrug().Name()} with:");
                foreach(IIngredient ingredient in genericMix.Ingredients()){
                    Console.WriteLine($"--> {ingredient.Name()} ({Math.Round(ingredient.Cost())}$)");
                }
                Console.WriteLine("Effects:");
                foreach(EffectListItem effect in genericMix.Effects().GetEffects()){
                    Console.WriteLine($"{effect.Effect.Name()}");
                }
                Console.WriteLine("-------------");
                Console.WriteLine($"Value:  {Math.Round(genericMix.Value())}$");
                Console.WriteLine($"Cost:   {Math.Round(genericMix.Cost())}$");
                Console.WriteLine($"Profit: {Math.Round(genericMix.Profit())}$");
                Console.WriteLine("");
                found = true;
                ContinueMenu();
                return;
            });
        });
        mixes = newMixes;
    }
}

List<IEffect> InitEffects(){
    return [
        new AntiGravity(),
        new Athletic(),
        new Balding(),
        new BrightEyed(),
        new Calming(),
        new CalorieDense(),
        new Cyclopean(),
        new Disorienting(),
        new Electrifying(),
        new Energizing(),
        new Euphoric(),
        new Explosive(),
        new Focused(),
        new Foggy(),
        new Gingeritis(),
        new Glowing(),
        new Jennerising(),
        new Laxative(),
        new LongFaced(),
        new Munchies(),
        new Paranoia(),
        new Refreshing(),
        new Schizophrenic(),
        new Sedating(),
        new SeizureInducing(),
        new Shrinking(),
        new Slippery(),
        new Smelly(),
        new Sneaky(),
        new Spicy(),
        new ThoughtProvoking(),
        new Toxic(),
        new TropicThunder(),
        new Zombifying()
    ];
}
