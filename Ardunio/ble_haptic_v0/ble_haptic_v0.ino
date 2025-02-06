#include <ArduinoBLE.h>
#include <U8x8lib.h>
#include <Wire.h>

BLEService ledService("19B10000-E8F2-537E-4F6C-D104768A1214"); // Bluetooth® Low Energy LED Service

// Bluetooth® Low Energy LED Switch Characteristic - custom 128-bit UUID, read and writable by central
BLEByteCharacteristic switchCharacteristic("19B10001-E8F2-537E-4F6C-D104768A1214", BLERead | BLEWrite);

const int ledPin = LED_BUILTIN; // pin to use for the LED


U8X8_SSD1306_128X64_NONAME_HW_I2C u8x8(/* clock=*/ 5, /* data=*/ 4, /* reset=*/ U8X8_PIN_NONE);   // OLEDs without Reset of the Display
String Text = "HandShake?";




void setup() {
  // Serial.begin(9600);
  // while (!Serial);

    u8x8.begin();
  u8x8.setFlipMode(2);   // set number from 1 to 3, the screen word will rotary 180
  u8x8.setFont(u8x8_font_chroma48medium8_r);

   // initialize the buzzer pin as an output:
        pinMode(3, OUTPUT);

    //
    // initialize the vibrator pin as an output:
    pinMode(0, OUTPUT);

  // set LED pin to output mode
  pinMode(ledPin, OUTPUT);

    pinMode(LED_GREEN, OUTPUT);

  // begin initialization
  if (!BLE.begin()) {
    // Serial.println("starting Bluetooth® Low Energy module failed!");
  u8x8.setCursor(0, 0);
  u8x8.print("starting Bluetooth® Low Energy module failed!");

    while (1);
  }



  // set advertised local name and service UUID:
  BLE.setLocalName("LED");
  BLE.setAdvertisedService(ledService);
    u8x8.setCursor(1, 1);
  u8x8.print("BLE HAPTIC");

  // add the characteristic to the service
  ledService.addCharacteristic(switchCharacteristic);

  // add service
  BLE.addService(ledService);

  // set the initial value for the characeristic:
  switchCharacteristic.writeValue(0);

  // start advertising
  BLE.advertise();

  // Serial.println("BLE LED Peripheral");
      u8x8.setCursor(1, 2);
  u8x8.print("BLE LED");
}

void loop() {
  // listen for Bluetooth® Low Energy peripherals to connect:
  BLEDevice central = BLE.central();

  // if a central is connected to peripheral:
  if (central) {
    Serial.print("Connected to central: ");
        u8x8.setCursor(1, 3);
  u8x8.print("Connected ");
          u8x8.setCursor(2, 4);
  u8x8.print(central.address());
    // print the central's MAC address:
    Serial.println(central.address());

    // while the central is still connected to peripheral:
  while (central.connected()) {
        if (switchCharacteristic.written()) {
                    u8x8.setCursor(4, 7);
                    u8x8.print("   ");
                    
                    u8x8.setCursor(4, 7);
                    u8x8.print(switchCharacteristic.value());

                    digitalWrite(3, HIGH);  // turn the Buzzer on (HIGH is the voltage level)
                    digitalWrite(LED_GREEN, LOW);

                    delay(100);
                    
                    digitalWrite(3, LOW);  // turn the Buzzer off (HIGH is the voltage level)
                    digitalWrite(LED_GREEN, HIGH);

          if (switchCharacteristic.value()) {   
            // Serial.println("LED on");
            digitalWrite(ledPin, LOW); // changed from HIGH to LOW    

            digitalWrite(0, HIGH);  // turn the vibrator on (HIGH is the voltage level)
            delay(switchCharacteristic.value()*10);
            digitalWrite(0, LOW);  // turn the vibrator off (HIGH is the voltage level)

            delay(80);
            digitalWrite(ledPin, HIGH); // changed from LOW to HIGH     

          } else {                              
            // Serial.println(F("LED off"));
            digitalWrite(ledPin, HIGH); // changed from LOW to HIGH     
          }
        }
      }

    // when the central disconnects, print it out:
    // Serial.print(F("Disconnected from central: "));
    // Serial.println(central.address());
                        
    u8x8.setCursor(1, 3);
    u8x8.print("Disconnected");
  }
}