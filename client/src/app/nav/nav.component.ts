import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  //2 way binding
  model: any = {};

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe(
      (res) => {
        this.toastr.success(`Welcome ${this.model.username}`);
        this.router.navigateByUrl('/members');
      },
      (err) => {
        console.log(err.error);
        this.toastr.error(err.error);
      }
    );
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe(
  //     (user) => {
  //       this.loggedIn = !!user;
  //       // !! - false if null true if not null
  //     },
  //     (err) => {
  //       console.log(err);
  //     }
  //   );
  // }
}
