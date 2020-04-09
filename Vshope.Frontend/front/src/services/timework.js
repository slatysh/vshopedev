import moment from 'moment'

export const TimeworkMomentFormat = function (dateTime) {
  if (dateTime == null) {
    return null
  }
  return moment(dateTime).format('YYYY-MM-DD')
}

export const TimeworkMomentParse = function (dateTime) {
  if (dateTime == null) {
    return null
  }
  return moment(dateTime, 'YYYY-MM-DD')
}
