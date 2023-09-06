import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isLoggedInFlag = false; // مؤشر لحالة تسجيل الدخول

  constructor() {}

  login(username: string, password: string): boolean {
    // قم بتنفيذ طلب HTTP أو أي عملية تسجيل الدخول اللازمة هنا
    // قم بالتحقق من صحة اسم المستخدم وكلمة المرور واسترجاع النتيجة

    // لأغراض المثال، سنقوم بتحقق بسيط باستخدام اسم المستخدم "admin" وكلمة المرور "password"
    if (username === 'admin' && password === 'password') {
      this.isLoggedInFlag = true; // تم تسجيل الدخول بنجاح
      return true;
    } else {
      this.isLoggedInFlag = false; // فشل تسجيل الدخول
      return false;
    }
  }

  logout(): void {
    // قم بتنفيذ طلب HTTP أو أي عملية تسجيل الخروج اللازمة هنا
    // قم بإعادة ضبط الحالة وتسجيل الدخول

    this.isLoggedInFlag = false; // تم تسجيل الخروج بنجاح
  }

  isLoggedIn(): boolean {
    return this.isLoggedInFlag;
  }
}
