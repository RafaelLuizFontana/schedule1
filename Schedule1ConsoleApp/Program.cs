// See https://aka.ms/new-console-template for more information
using Schedule1ConsoleApp.Model;
using Schedule1ConsoleApp.Model.Drug;
using Schedule1ConsoleApp.Model.Ingredient;
using Schedule1ConsoleApp.Model.Interface;

List<IIngredient> ingredients;
List<GenericMix> mixes;
IBaseDrug? drug;
int iterations;
string? input;
bool exitApp;
bool backToFeatureMenu;
bool findMixSelected;
bool doneSelectingEffects;

int mixNumber;

InitIngrediets();
InitApp();
Console.WriteLine("Welcome to the Schedule 1 Console App!");
Console.WriteLine("");
SelectFeatureMenu();

void InitIngrediets()
{
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
}

void InitApp()
{
    drug = null;
    mixes = [];
    iterations = 0;
    exitApp = false;
    backToFeatureMenu = false;
    findMixSelected = true;
    doneSelectingEffects = false;
}

void SelectFeatureMessage(){
    Console.WriteLine("Please select an option:");
    Console.WriteLine("");
    Console.WriteLine("1 - Find the most profitable mix");
    Console.WriteLine("2 - Chose effects to find a mix");
    ExitAppMessage();
    Console.WriteLine("");
}

void SelectFeatureMenu()
{
    while (!exitApp)
    {
        SelectFeatureMessage();
        input = Console.ReadLine();
        switch (input)
        {
            case "1":
                findMixSelected = true;
                SelectDrugMenu();
                break;
            case "2":
                findMixSelected = false;
                SelectDrugMenu();
                break;
            case "0":
                exitApp = true;
                break;
            default:
                InvalidSelectionMessage();
                break;
        }
    }
    ExitMessage();
}

void ExitAppMessage(){
    Console.WriteLine("0 - Exit App");
}

void ExitMessage(){
    Console.WriteLine("Thanks for using Schedule I App!");
}

void InvalidSelectionMessage(){
    Console.WriteLine("Invalid selection");
    Console.WriteLine("");
}

void BackMessage(){
    Console.WriteLine("9 - Back to previous menu");
}

void BackToPreviousMenuMessage(){
    Console.WriteLine("You selected Back to previous menu");
    Console.WriteLine("");
}

void SelectDrugMessage(){
    Console.WriteLine("Please select a drug to start:");
        Console.WriteLine("");
        Console.WriteLine("1 - OG Kush ($38)");
        Console.WriteLine("2 - Sour Diesel ($40)");
        Console.WriteLine("3 - Green Crack ($43)");
        Console.WriteLine("4 - Granddaddy Purple ($44)");
        Console.WriteLine("5 - Methamphetamine ($70)");
        Console.WriteLine("6 - Cocaine ($150)");
        BackMessage();
        ExitAppMessage();
        Console.WriteLine("");
}

void SelectDrugMenu(){
    backToFeatureMenu = false;
    while (!backToFeatureMenu && !exitApp)
    {
        SelectDrugMessage();
        input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("You selected OG Kush.");
                Console.WriteLine("");
                drug = new OGKush();
                DrugSelectedFlow();
                break;
            case "2":
                Console.WriteLine("You selected Sour Diesel.");
                Console.WriteLine("");
                drug = new SourDiesel();
                DrugSelectedFlow();
                break;
            case "3":
                Console.WriteLine("You selected Green Crack.");
                Console.WriteLine("");
                drug = new GreenCrack();
                DrugSelectedFlow();
                break;
            case "4":
                Console.WriteLine("You selected Granddaddy Purple.");
                Console.WriteLine("");
                drug = new GranddaddyPurple();
                DrugSelectedFlow();
                break;
            case "5":
                Console.WriteLine("You selected Methamphetamine.");
                Console.WriteLine("");
                drug = new Meth();
                DrugSelectedFlow();
                break;
            case "6":
                Console.WriteLine("You selected Cocaine.");
                Console.WriteLine("");
                drug = new Coke();
                DrugSelectedFlow();
                break;
            case "9":
                BackToPreviousMenuMessage();
                backToFeatureMenu = true;
                break;
            case "0":
                ExitMessage();
                exitApp = true;
                break;
            default:
                InvalidSelectionMessage();
                break;
        }
    }
}

void DrugSelectedFlow(){
    if(findMixSelected){
        SelectNumberOfMixesMenu();
    }else{
        FindMixMenu();
    }
}

void SelectNumberOfMixesMessage(){
    Console.WriteLine("Please select a number of mixes you want (or 0 to exit):");
    Console.WriteLine("");
}

void SelectNumberOfMixesMenu(){
    SelectNumberOfMixesMessage();
    while (!backToFeatureMenu && !exitApp){
        input = Console.ReadLine();
        if (int.TryParse(input, out int numberOfMixes) && numberOfMixes > 0)
        {
            StartMixing(numberOfMixes);
        }
        else if (input == "0")
        {
            exitApp = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive number or 0 to exit.");
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

void ContinueMenu(){
    Console.WriteLine("Continue mixing? (y/n)");
    bool enterYesNo = false;
    while (!enterYesNo){
        input = Console.ReadLine();
        if (input == "y" || input == "Y")
        {
            InitApp();
            enterYesNo = true;
            backToFeatureMenu = true;
        }
        else if (input == "n" || input == "N")
        {
            enterYesNo = true;
            exitApp = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
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

void FindMixMenu(){
    EffectList effectList = new();
    while(!doneSelectingEffects && !backToFeatureMenu){
        List<IEffect> effectsToSelect = InitEffects();
        Console.WriteLine("Please select the desired effect (or 0 to exit):");
        Console.WriteLine("");
        for (int i = 0; i<effectsToSelect.Count; i++){
            if(!effectList.HasEffect(effectsToSelect[i]))Console.Write($"{i+1}){effectsToSelect[i].Name()} ");
        }
        Console.WriteLine("");
        input = Console.ReadLine();
        if(input == "0"){
            backToFeatureMenu = true;
        }else if(int.TryParse(input, out int index) && index - 1 < 34 && !effectList.HasEffect(effectsToSelect[index-1])){
            Console.WriteLine($"You selected {effectsToSelect[index-1].Name()}");
            effectList.SetEffect(effectsToSelect[index-1]);
            Console.WriteLine("");
            Console.WriteLine("Continue selecting? (y/n)");
            bool enterYesNo = false;
            while (!enterYesNo){
                input = Console.ReadLine();
                if (input == "y" || input == "Y"){
                    enterYesNo = true;

                }else if (input == "n" || input == "N")
                {
                    doneSelectingEffects = true;
                    enterYesNo = true;
                    FindMix(effectList);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        } else {
            Console.WriteLine("Invalid input. Please enter a positive number or 0 to exit.");
        }
    }
}

void FindMix(EffectList effectList){
    FirstMix();
    bool found = false;
    GenericMix genericMix;
    while(!found){
        List<GenericMix> newMixes = [];
        //Loop for all ingredients
        for(int i=0; i<ingredients.Count; i++)
        {
            //loop for all existent mixes
            var ingredient = ingredients[i];
            for(int i2=0; i2<mixes.Count; i2++)
            {
                genericMix = new(mixes[i2]);
                genericMix.AddIngredient(ingredient);
                //If this mix doesn't exist in the mixes list then add
                if (!mixes.Any(x => x.Equals(genericMix)))
                {
                    //Loop for all desired effects
                    for (int i3 = 0; i3 < effectList.Count(); i3++)
                    {
                        var effectListItem = effectList.GetEffects()[i3];
                        //If this mix with this ingredient dos not have the desired effect, add to mixes list to further mixes
                        found = true;
                        if (!genericMix.Effects().HasEffect(effectListItem.Effect))
                        {
                            newMixes.Add(genericMix);
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        Console.WriteLine("Mix found:");
                        Console.WriteLine($"{genericMix.BaseDrug().Name()} with:");
                        foreach (IIngredient ingr in genericMix.Ingredients())
                        {
                            Console.WriteLine($"--> {ingr.Name()} ({Math.Round(ingr.Cost())}$)");
                        }
                        Console.WriteLine("Effects:");
                        foreach (EffectListItem effect in genericMix.Effects().GetEffects())
                        {
                            Console.WriteLine($"{effect.Effect.Name()}");
                        }
                        Console.WriteLine("-------------");
                        Console.WriteLine($"Value:  {Math.Round(genericMix.Value())}$");
                        Console.WriteLine($"Cost:   {Math.Round(genericMix.Cost())}$");
                        Console.WriteLine($"Profit: {Math.Round(genericMix.Profit())}$");
                        Console.WriteLine("");
                        break;
                    }
                }
            }
            if (found)
            {
                ContinueMenu();
                break;
            }
        }
        if (found) break;
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
