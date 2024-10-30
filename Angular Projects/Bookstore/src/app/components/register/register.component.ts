import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr'; // Assuming you're using ngx-toastr
import { AuthService } from '../../services/classes/auth.service'; // Adjust the path accordingly

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService) {}

  onSubmit() {
    const user = {
      firstName: this.firstName,
      lastName: this.lastName,
      email: this.email,
      password: this.password
    };

    // Perform registration logic
    const isRegistered = this.authService.register(this.firstName,this.lastName,this.email,this.password);

    if (isRegistered) {
      this.toastr.success('Registration successful!', 'Success');
      this.router.navigate(['/login']); // Navigate to the login page or home
    } else {
      this.toastr.error('Registration failed. Please try again.', 'Error');
    }
  }
}
