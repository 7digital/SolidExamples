Actions I've taken:

- Created a user repository to remove the responsibility of persistence out of the user class

- Turned the authentication class into a command object which takes the username and password in 
  the constructor which allows me to make them immutable so I don't have to pass them between all 
  the methods which looks messy.
  
- Used Resharper_ExtractMethod (Ctrl R + Ctrl M) and pulled the responsibility to decide whether 
  the user is "valid" out into a separate method and then again with the MaxLoginAttempts test 
  and the Password test
  
- Used Resharper_ExtractInterface (no shortcut) and given the repository an interface and passed
  it into the constructor of the authenticationcommand thus decoupling the concrete persistence 
  class from it (This is known as dependency injection and is related to the D in SOLDI). This 
  would also make it easier to test the units in isolation rather than with integration tests 
  as it is now... if this was not just an example I would do so.
