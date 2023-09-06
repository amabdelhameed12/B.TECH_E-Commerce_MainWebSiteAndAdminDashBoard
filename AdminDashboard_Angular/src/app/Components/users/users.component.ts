import { Component, OnInit } from '@angular/core';
import { Users } from 'src/app/Model/Users';
import { UsersService } from 'src/app/Servics/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  users: Users[] = [];

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.usersService.GetAllUsers().subscribe((data: Users[]) => {
      this.users = data;
      console.log(this.users);
    });
  }
}