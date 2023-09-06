import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdminSerService } from 'src/app/Servics/admin-ser.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username: string = '';
  password: string = '';
  error: string = '';

  constructor(
    private adminService: AdminSerService,
    private router: Router
  ) {}

  onSubmit() {
    this.adminService.login(this.username, this.password).subscribe(
      result => {
        if (result) {
          // Successful login
          this.adminService.setLoggedIn(true);
          this.router.navigate(['/MainLayoutComponent']);
        } else {
          // Failed login
          this.error = 'Invalid username or password, please try again';
        }
      },
      error => {
        this.error = 'An error occurred while trying to login.';
      }
    );
  }
}
