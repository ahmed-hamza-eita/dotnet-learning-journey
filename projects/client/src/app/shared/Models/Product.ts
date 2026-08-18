export interface IProduct {
  id: number
  name: string
  description: string
  newPrice: number
  oldPrice: number
  categoryId: number
  categoryName: string
  photos: IPhoto[]
}

export interface IPhoto {
  id: number
  name: string
  productId: number
}
