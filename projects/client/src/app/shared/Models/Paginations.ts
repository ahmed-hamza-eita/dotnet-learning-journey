import { IProduct } from "./Product"

export interface Root {
  statusCode: number
  message: string
  data: Data
}

export interface Data {
  data: IProduct[]
  currentPage: number
  pageSize: number
  totalItems: number
  totalPages: number
}

