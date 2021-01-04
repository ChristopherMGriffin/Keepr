import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class KeepService {
  async create(newKeep) {
    try {
      const res = await api.post('api/keeps', newKeep)
      logger.log(res.data)
      this.getAll()
    } catch (e) {
      logger.log(e)
    }
  }

  async deleteKeep(id) {
    try {
      const res = await api.delete('api/keeps/' + id)
      logger.log(res)
      this.getAll()
    } catch (e) {
      logger.log(e)
    }
  }

  async getAll() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
      logger.log('keeps', AppState.keeps)
    } catch (e) {
      logger.log(e)
    }
  }

  async getOne(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      AppState.activeKeep = res.data
      logger.log(AppState.activeKeep)
    } catch (e) {
      logger.log(e)
    }
  }
}

export const keepService = new KeepService()
