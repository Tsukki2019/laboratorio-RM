const int button1 = 4;
const int button2 = 5;
const int button3 = 6;
const int button4 = 7;

const int potentiometer = A0;

void setup()
{
  Serial.begin(9600);

  pinMode(button1, INPUT_PULLUP);
  pinMode(button2, INPUT_PULLUP);
  pinMode(button3, INPUT_PULLUP);
  pinMode(button4, INPUT_PULLUP);
}

void loop()
{
  byte b1 = digitalRead(button1);
  byte b2 = digitalRead(button2);
  byte b3 = digitalRead(button3);
  byte b4 = digitalRead(button4);

  int pot = analogRead(potentiometer);

  byte potH = highByte(pot);
  byte potL = lowByte(pot);

  
  byte checksum =
      b1 + b2 + b3 + b4 + potH + potL;

 
  Serial.write(0xAA);      
  Serial.write(6);         

  Serial.write(b1);
  Serial.write(b2);
  Serial.write(b3);
  Serial.write(b4);

  Serial.write(potH);
  Serial.write(potL);

  Serial.write(checksum);

  delay(50);
}