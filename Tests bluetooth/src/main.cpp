#include <Arduino.h>

/*
--------------------RÉFÉRENCES-----------------
https://www.arduino.cc/en/Tutorial/BuiltInExamples/MultiSerialMega
https://www.arduino.cc/en/Reference/StringLibrary
https://www.arduino.cc/reference/en/language/functions/communication/serial/readstring/
https://www.arduino.cc/reference/en/language/functions/communication/serial/read/
https://www.arduino.cc/reference/en/language/functions/communication/serial/
https://maker.pro/arduino/tutorial/bluetooth-basics-how-to-control-led-using-smartphone-arduino#:~:text=Arduino%20Pins%20%7C%20Bluetooth%20Pins&text=Connect%20an%20LED%20positive%20to,jumper%20wires%20and%20a%20connector.
http://www.dsdtech-global.com/2017/09/sh-m08.html
*/


String incomingByte = ""; // for incoming serial data
String outMessage = "";
int mode = 0; //0 for read-write and 1 for read only
void setup() {
  // put your setup code here, to run once:
  //Initialise le port de communication et attend pour l'ouvrir:
  Serial.begin(9600);
  Serial1.begin(9600);
  
  //Ce delai permet de s'assurer que le moniteur serie (Serial monitor) soit disponible
  delay(1500);
}

void loop() {

  if(mode == 0){
      if (Serial1.available() > 0) {
      // read the incoming byte:
      incomingByte = Serial1.readString();

      // say what you got:
      Serial.print("I received: ");
      Serial.println(incomingByte);
    }
    if (Serial.available() > 0) {
      // read the incoming byte:
      outMessage = Serial.readString();

      // say what you got:
      Serial.print(outMessage);
      Serial1.print(outMessage);
    }
  }else if(mode == 1){
    if (Serial1.available() > 0) {
      // read the incoming byte:
      incomingByte = Serial1.readString();

      // say what you got:
      Serial.print("I received: ");
      Serial.println(incomingByte);
    }
  }else{
    Serial.println("How did you get here ?");
  }
  
  /*
  // put your main code here, to run repeatedly:
  Serial.println("Bonjour le monde!");
  Serial1.println("Hello Bluetooth !");

  delay(3000);
  */
}