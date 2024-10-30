// form-builder.service.ts
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormBuilderService {
  constructor(private fb: FormBuilder) {}

  // Create a method that builds the form
  buildBillingForm(): FormGroup {
    return this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      adress: ['', Validators.required],
      city: ['', Validators.required],
      email: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$')
        ]
      ],
      phone: [
        '',
        [
           Validators.required,
          Validators.pattern(
            '^\\+?[0-9]{1,4}?[-.\\s]?\\(?[0-9]{1,3}?\\)?[-.\\s]?[0-9]{1,4}[-.\\s]?[0-9]{1,9}$'
          )
        ]
      ],
    });
  }
  AddCategoryForm(): FormGroup {
    return this.fb.group({
      ItemName: ['', Validators.required],
      SalesPrice: ['', Validators.required],
      PurchasePrice: ['', Validators.required],
      description: ['', [
        Validators.required,
        Validators.pattern(/^.{10,300}$/) // Short description between 10 to 100 characters
      ]],

    });
  }
}
