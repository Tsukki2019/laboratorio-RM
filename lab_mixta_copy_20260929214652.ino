const int button1 = 4;
const int button2 = 5;
const int button3 = 6;
const int button4 = 7;

const int potenciometro = A0;

void setup() {
  Serial.begin(9600);

  pinMode(button1, INPUT_PULLUP);
  pinMode(button2, INPUT_PULLUP);
  pinMode(button3, INPUT_PULLUP);
  pinMode(button4, INPUT_PULLUP);
}

void loop() {

  int b1 = digitalRead(button1);
  int b2 = digitalRead(button2);
  int b3 = digitalRead(button3);
  int b4 = digitalRead(button4);

  int pot = analogRead(potenciometro);

  // Protocolo CSV
  Serial.print(b1);
  Serial.print(",");
  Serial.print(b2);
  Serial.print(",");
  Serial.print(b3);
  Serial.print(",");
  Serial.print(b4);
  Serial.print(",");
  Serial.println(pot);

  delay(50);
}