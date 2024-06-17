using laba3;

Inch inchA = new Inch() { Value = 4 };
Inch inchB = new Inch() { Value = 9 };

Meter meterA = new Meter() { Value = 4 };
Meter cloneMeterA = new Meter() { Value = 4 };
Meter meterB = new Meter() { Value = 9 };


// арифметические операторы +, -, *, /
Console.WriteLine("Meter");
Console.WriteLine($"meterA={meterA} meterB={meterB}");

Console.WriteLine($"арифметические операторы + 4+9={meterA + meterB}");
Console.WriteLine($"арифметические операторы - 4-9={meterA - meterB}");
Console.WriteLine($"арифметические операторы * 4*9={meterA * meterB}");
Console.WriteLine($"арифметические операторы / 4/9={meterA / meterB}");
// унарные + и -
meterA++;
meterB--;
Console.WriteLine($"унарные ++ meterA={meterA}");
Console.WriteLine($"унарные -- meterB={meterB}");

meterA.Value = 4; // reset value

// операторы сравнения ==, !=, >, <, >=, <=
Console.WriteLine($"операторы сравнения == 4==9 {meterA == meterB}");
Console.WriteLine($"операторы сравнения == 4==4 {meterA == cloneMeterA}");
Console.WriteLine($"операторы сравнения != 4!=9 {meterA == meterB}");
Console.WriteLine($"операторы сравнения != 4>9 {meterA > meterB}");
Console.WriteLine($"операторы сравнения != 4<9 {meterA < meterB}");
Console.WriteLine($"операторы сравнения != 4>=9 {meterA >= meterB}");
Console.WriteLine($"операторы сравнения != 4<=9 {meterA <= meterB}");
Console.WriteLine($"операторы сравнения != 4>=4 {meterA >= cloneMeterA}");
Console.WriteLine($"операторы сравнения != 4>=4 {meterA <= cloneMeterA}");

// методы ToString, GetHashCode и Equals

Console.WriteLine($"ToString Meter 4  =  {cloneMeterA.ToString()}");
Console.WriteLine($"GetHashCode Meter 4  =  {cloneMeterA.GetHashCode()}");
Console.WriteLine($"Equals 4=9  {cloneMeterA.Equals(meterB)}");
Console.WriteLine($"Equals 4=4  {cloneMeterA.Equals(meterA)}");

// операторы явного и неявного приведения типа

Console.WriteLine($"---\nInch {inchA}");

Meter meterWhoGetFromInch = inchA;

Console.WriteLine($"Inch->Meter Meter:{meterWhoGetFromInch}");

Inch ReturnMeter = meterWhoGetFromInch;
Console.WriteLine($"Meter->Inch Inch:{ReturnMeter}");

Console.Read();