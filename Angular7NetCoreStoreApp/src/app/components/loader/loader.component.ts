import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

import { LoaderService } from '../../services/helpers/loader/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {
  color = 'primary';
  mode = 'indeterminate';
  value = 50;
  isLoading$: Subject<boolean>;

  constructor(private loaderService: LoaderService) { }

  ngOnInit() {
    this.isLoading$ = this.loaderService.isLoading;
  }

}
