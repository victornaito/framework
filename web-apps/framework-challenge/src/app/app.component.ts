import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'framework-challenge';
  result: any = null;

  constructor(public httpClient: HttpClient) {

  }

  ngOnInit(): void {
  }

  public getDivisor(number: number) {
    this.httpClient.get(`https://localhost:49164/Math/divisors/${number}`).subscribe(_ => this.result = _);
  }
}

