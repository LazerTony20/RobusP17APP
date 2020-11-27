#include <Arduino.h>

void setup() {
  // put your setup code here, to run once:
  //Initialise le port de communication et attend pour l'ouvrir:
  Serial.begin(9600);
  //Ce delai permet de s'assurer que le moniteur serie (Serial monitor) soit disponible
  delay(1500);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("Bonjour le monde!");

  delay(10000);
}