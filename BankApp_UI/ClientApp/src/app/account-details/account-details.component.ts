import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

const DETAILS = 'https://localhost:7142/api/BankAccounts';
const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  id!: string | null;
  account: any;
  amount: number = 0;

  @ViewChild('balance')
  bal!: ElementRef;

  @ViewChild('depositAmt')
  dep!: ElementRef;

  @ViewChild('withdrawAmt')
  wit!: ElementRef;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    let link = DETAILS + "/" + this.id;
    this.http.get(link).subscribe((data) => {
      this.account = data;
    });
  }

  deposit(amount: string) {
    let link = DETAILS + "/deposit/" + this.id + "/" + amount;
    this.http.put(link, httpOptions).subscribe((succ) => {
      console.log(succ);
      this.dep.nativeElement.value = "";
    },(err) => {
      console.log(err);
    });
  }

  balanceCheck() {
    let link = DETAILS + "/" + this.id;
    this.http.get(link).subscribe((data) => {
      this.account = data;
      this.bal.nativeElement.value = this.account.balance;
    });
  }

  withdraw(amount: string) {
    let link = DETAILS + "/withdraw/" + this.id + "/" + amount;
    this.http.put(link, httpOptions).subscribe((succ) => {
      console.log(succ);
      this.wit.nativeElement.value = "";
    }, (err) => {
      console.log(err);
    });
  }

}
