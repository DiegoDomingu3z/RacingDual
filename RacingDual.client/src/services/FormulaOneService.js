import axios from "axios"
import { AppState } from "../AppState"
import { logger } from "../utils/Logger"

const FormulaApi = axios.create({
    baseURL: 'http://api.sportradar.us/formula1/trial/v2/en',
    // headers: 'Access-Control-Allow-Origin: *',
    setTimeout: 5000
})


class FormulaOneService {

    async getCurrentSeasonSchedule() {
        const res = await FormulaApi.get('/seasons.json?api_key=7fmnkkfvc8c455t2yng6ve73')
        logger.log(res.data)
        AppState.f1 = res.data

    }



}


export const formulaOneService = new FormulaOneService()