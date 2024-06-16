using laba1;

var statistics = new Statistics();
var dictionary = new Dictionary<Language, string[]>();
var random = new Random();

string[] optionsRus = {
    "Вчера я приехал в Пятигорск, нанял квартиру на краю города, на самом высоком месте, у подошвы Машука.",
    "Весело жить в такой земле! ",
    "Под виноградными аллеями, покрывающими скат Машука, мелькали порою пестрые шляпки любительниц уединения вдвоем.",
    "Печорин! давно ли здесь?",
    "Мы встретились старыми приятелями."
};

string[] optionsEng = {
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
    "In hac habitasse platea dictumst vestibulum rhoncus est pellentesque.",
    "Neque vitae tempus quam pellentesque nec nam aliquam sem et.",
    "At volutpat diam ut venenatis tellus in.",
    "Cursus metus aliquam eleifend mi in nulla.",
    "Et ultrices neque ornare aenean euismod elementum nisi quis eleifend.",
    "Suspendisse potenti nullam ac tortor vitae purus.",
    "Cursus risus at ultrices mi tempus imperdiet nulla malesuada.",
    "Orci a scelerisque purus semper.",
    "Odio euismod lacinia at quis risus sed vulputate odio ut."
};

dictionary.Add(Language.English, optionsEng);
dictionary.Add(Language.Russian, optionsRus);

void showMeMyWritingSpeed()
{
    statistics.incrementCountAttemp();
    var storage = new Storage();
    //Console.Clear();

    string[] arrayWithTexts;
    Console.WriteLine("Выберите язык выводимых предложений. По умолчанию - Русский\nru - Russian \nen - English");
    var selectLanguage = Console.ReadLine();

    arrayWithTexts = dictionary[selectLanguage == "en" ? Language.English : Language.Russian];

    storage.numberSelectText = random.Next(0, arrayWithTexts.Length);
    var myRandomText = arrayWithTexts[storage.numberSelectText];
    var countChars = myRandomText.Length;


    Console.WriteLine("Для старта нажмите Enter");
    Console.ReadLine();
    Console.WriteLine($"Введите текст ниже:\n{myRandomText}"); ;

    DateTime startedAt = DateTime.Now;
    var insertText = Console.ReadLine();
    storage.timeWriting = DateTime.Now - startedAt;

    var speed = Helper.calculateSpeed(storage.timeWriting, insertText.Length);
    statistics.updateSpeed(speed);
    storage.countError = Helper.getCountErrors(myRandomText, insertText!);
    Console.Write($"Cкорость печати: {speed} знаков/мин, ошибок {storage.countError} \n");
    Console.Write($"Y вас было {statistics.countAttempts} попыток, средняя скорость - {statistics.averageSpeed} зн/мин, лучшая - {statistics.bestSpeed} зн/мин, худшая {statistics.worstSpeed} зн/мин \n \n");

    Console.WriteLine("Для повтора нажми Enter");
    Console.ReadLine();
    showMeMyWritingSpeed();
}

showMeMyWritingSpeed();
