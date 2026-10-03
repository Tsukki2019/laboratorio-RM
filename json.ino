const int boton1 = 4;
const int boton2 = 5;
const int boton3 = 6;
const int boton4 = 7;

const int potenciometro = A0;

void setup()
{
  Serial.begin(9600);

  pinMode(boton1, INPUT_PULLUP);
  pinMode(boton2, INPUT_PULLUP);
  pinMode(boton3, INPUT_PULLUP);
  pinMode(boton4, INPUT_PULLUP);
}

void loop()
{
  int b1 = digitalRead(boton1);
  int b2 = digitalRead(boton2);
  int b3 = digitalRead(boton3);
  int b4 = digitalRead(boton4);

  int pot = analogRead(potenciometro);

  Serial.print("{\"b1\":");
  Serial.print(b1);

  Serial.print(",\"b2\":");
  Serial.print(b2);

  Serial.print(",\"b3\":");
  Serial.print(b3);

  Serial.print(",\"b4\":");
  Serial.print(b4);

  Serial.print(",\"pot\":");
  Serial.print(pot);

  Serial.println("}");

  delay(50);
}