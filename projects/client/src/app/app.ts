  import { HttpClient } from '@angular/common/http';
  import { Component, OnInit, signal } from '@angular/core';

  @Component({
    selector: 'app-root',
    templateUrl: './app.html',
    standalone: false,
    styleUrl: './app.scss',
  })
  export class App implements OnInit {
    protected readonly title = signal('client');

    baseUrl = 'https://localhost:7219/api/Products/get-all';
    Category: any;

    getCategory() {
      return this.http.get(this.baseUrl).subscribe({
        next: (value: any) => {
          this.Category = value.data
          console.log(value)
        },
      });
    }

    constructor(private http: HttpClient) {}

    ngOnInit(): void {
      this.getCategory()
    }
  }
