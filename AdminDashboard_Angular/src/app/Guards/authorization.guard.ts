// import { Injectable } from '@angular/core';
// import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
// import { Observable } from 'rxjs';
// import { AdminSerService } from '../Servics/admin-ser.service';
// import { AuthService } from '../Servics/auth.service';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthGuard implements CanActivate {
//   constructor(private authService: AuthService, private router: Router) {}

//   canActivate(): boolean {
//     const isLoggedIn = this.authService.isLoggedIn();

//     if (isLoggedIn) {
//       return true;
//     } else {
//       // إذا لم يكن المستخدم مسجلاً الدخول، قم بتوجيهه إلى صفحة تسجيل الدخول أو أي صفحة أخرى ترغب فيها
//       this.router.navigate(['/login']);
//       return false;
//     }
// }}



import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AdminSerService } from '../Servics/admin-ser.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {
  constructor(
    private adminService: AdminSerService,
    private router: Router
  ) {}

  canActivate(): boolean {
    if (!this.adminService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return false;
    } else {
      return true;
    }
  }
  
}