import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedInStatus = false;

  constructor() {
    // Check if user is already logged in
    this.loggedInStatus = localStorage.getItem('isLoggedIn') === 'true';
  }

  // Register new user
  register(firstName: string, lastName: string, email: string, password: string): boolean {
    const users = JSON.parse(localStorage.getItem('users') || '[]');

    // Check if the email already exists
    if (users.find((user: any) => user.email === email)) {
      return false; // Email already exists
    }

    // Add the new user to the users array
    users.push({ firstName, lastName, email, password });
    localStorage.setItem('users', JSON.stringify(users));
    console.log(`Registered users: ${JSON.stringify(users)}`);
    return true;
  }

  // Login user
  login(email: string, password: string): boolean {
    const users = JSON.parse(localStorage.getItem('users') || '[]');
    console.log(`Existing users: ${JSON.stringify(users)}`);

    // Find the user with the matching email and password
    const user = users.find((user: any) => user.email === email && user.password === password);

    if (user) {
      this.loggedInStatus = true;
      localStorage.setItem('isLoggedIn', 'true');
      return true;
    }
    return false;
  }

  // Logout user
  logout(): void {
    this.loggedInStatus = false;
    localStorage.setItem('isLoggedIn', 'false');
  }

  // Check if user is logged in
  isLoggedIn(): boolean {
    return this.loggedInStatus;
  }
}
