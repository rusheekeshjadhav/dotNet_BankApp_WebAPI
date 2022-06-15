import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
const ADD = 'https://localhost:7142/api/BankAccounts';

@Component({
  selector: 'app-open-account',
  templateUrl: './open-account.component.html',
  styleUrls: ['./open-account.component.css']
})
export class OpenAccountComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router) { }

  accType: string[] = ["", "Current", "Saving"];

  ngOnInit(): void {
  }

  myForm = new FormGroup({
    AccountHolder: new FormControl('', Validators.required),
    Balance: new FormControl('', Validators.required),
    AccountType: new FormControl('', Validators.required)
  });

  submit() {
    // console.log(this.myForm.value);
    // console.log(this.myForm.valid);

    if (this.myForm.valid) {
      /*console.log("valid");*/

      this.http.post(ADD, this.myForm.value, httpOptions).subscribe((succ) => {
        console.log(succ);
        this.router.navigate(['/accountDetails', succ]);
      },
        (err) => {
          console.log(err);
        });

      /*this.http.get('https://localhost:7142/api/BankAccounts').subscribe((succ) => {
        console.log(succ);
      },
        (err) => {
          console.log(err);
        });*/
    }
  }

  checkValid() {
    return this.myForm.valid;
  }

  /*toggleCheck(): void {
    this.ts.checked = !this.ts.checked;
    // console.log(this.ts.checked);
  }*/

}
