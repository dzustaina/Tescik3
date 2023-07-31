// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-registration-form',
//   templateUrl: './registration.component.html',
//   styleUrls: ['./registration.component.css']
// })
// export class RegistrationComponent {
//   name: string | undefined;
//   email: string | undefined;
//   password: string | undefined;

//   onSubmit() {
//     console.log('Registration form submitted!');
//     console.log(`Name: ${this.name}`);
//     console.log(`Email: ${this.email}`);
//     console.log(`Password: ${this.password}`);
//   }
// }





import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  constructor(public service: UserService) { }

  ngOnInit(){

  }
}
