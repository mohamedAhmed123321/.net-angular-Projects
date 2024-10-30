import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/classes/auth.service';
import { ToastrService } from 'ngx-toastr'; // Import ToastrService

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService // Inject ToastrService
  ) {}

  onLogin() {
    // Authenticate the user
    const isAuthenticated = this.authService.login(this.username,this.password);
    if (isAuthenticated) {
      this.toastr.success('Login successful!', 'Welcome'); // Use toaster for success
      this.router.navigate(['/home']); // Redirect to home page after successful login
    } else {
      this.toastr.error('Invalid username or password', 'Login Failed'); // Use toaster for error
    }
  }
}
